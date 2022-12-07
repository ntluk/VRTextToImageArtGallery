using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;
using System.Linq;
using System.Threading;

/// <summary>
/// Prompts go in, textures come out.
/// </summary>
public class Startup : MonoBehaviour
{
    // [SerializeField] InputField input;
    [SerializeField] GameObject image;
  
    public Process process;
    public StreamWriter streamWriter;
    private string prompt = "cute owl watercolor painting";
    private Thread thread;

    public bool bInitialized = false;

    private List<string> liLines = new List<string>();
    private List<string> liErrors = new List<string>();

    
    private OutputStatus outputStatus = OutputStatus.Unfinished;
    int c = 0;

    private enum OutputStatus { Unfinished, Broken, BrokenNeedsRestart, FinishedSuccessfully }

    public void Start()
    {
        process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += OnOutputDataReceived;
        process.ErrorDataReceived += OnOutputErrorReceived;

        process.Start();
        process.BeginOutputReadLine();

        streamWriter = process.StandardInput;

       
        if (streamWriter.BaseStream.CanWrite)
        {
            thread = new Thread(
                new ThreadStart(StartAI));
            thread.Start();
        }
    }

    public void StartAI()
    {
        UnityEngine.Debug.Log("Writing: " + $"cd InvokeAI");// \"{ToolManager.s_settings.strSDDirectory}\"
        streamWriter.WriteLine($"cd C:/Users/Chynvero/InvokeAI");

        UnityEngine.Debug.Log("Writing: " + "pew workon invoke-ai");
        streamWriter.WriteLine("pew workon invoke-ai");

        UnityEngine.Debug.Log("Writing: " + "python scripts/dream.py");
        streamWriter.WriteLine($"py scripts/dream.py --full_precision"); // --full_precision
    }
    public void Go()
    {
        outputStatus = OutputStatus.Unfinished;
        StartCoroutine(ieRequestImage());
    }

    private IEnumerator ieRequestImage()
    {
        UnityEngine.Debug.Log($"Requesting " + prompt);

        yield return new WaitUntil(() => streamWriter.BaseStream.CanWrite);
        streamWriter.WriteLine(prompt);

        yield return new WaitUntil(() => outputStatus != OutputStatus.Unfinished);

        if (outputStatus == OutputStatus.Broken || outputStatus == OutputStatus.BrokenNeedsRestart)
        {
            UnityEngine.Debug.Log("Could not generate image. Please use a smaller image.");
        }
        else
        {
            FileInfo fileLatestPng = new DirectoryInfo("C:/Users/Chynvero/InvokeAI/outputs/img-samples").GetFiles().Where(x => Path.GetExtension(x.Name) == ".png").OrderByDescending(f => f.LastWriteTime).First();

            UnityEngine.Debug.Log($" New file appeared! Loading {fileLatestPng.Name}");

            yield return new WaitUntil(() => !Utility.IsFileLocked(fileLatestPng));
            yield return new WaitForSeconds(0.1f); // just give it some time

            UnityEngine.Debug.Log($"Finished loading image.");

            Material mat = new Material(Shader.Find("Standard"));
            mat.mainTexture = Utility.texLoadImageSecure(fileLatestPng.FullName, mat.mainTexture as Texture2D);
            image.GetComponent<Renderer>().material = mat;
        }
    }
    private void ProcessOutput(string _strOutput)
    {
        UnityEngine.Debug.Log(">>>>>>>> " + _strOutput);

        if (_strOutput.StartsWith("* Initialization done!"))
        {
            bInitialized = true;
           
        }
      
            
        else if (outputStatus == OutputStatus.Unfinished && _strOutput.StartsWith("Outputs:"))
            outputStatus = OutputStatus.FinishedSuccessfully;
        else if (_strOutput.StartsWith(">> Could not generate image."))
            outputStatus = OutputStatus.Broken;
        else if (_strOutput.StartsWith("dream> CUDA out of memory"))
            outputStatus = OutputStatus.BrokenNeedsRestart;
    }

    private void Update()
    {
        foreach (string strLine in liLines)
            ProcessOutput(strLine);
        liLines.Clear();

        foreach (string strError in liErrors)
            UnityEngine.Debug.Log(strError);
        liErrors.Clear();

        

        if (bInitialized == true && c < 1)
        {
            Go();
            c++;
        }
           
    }

    private void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (string.IsNullOrEmpty(e.Data))
            return;
        liLines.Add(e.Data);
    }

    private void OnOutputErrorReceived(object sender, DataReceivedEventArgs e)
    {
        if (string.IsNullOrEmpty(e.Data))
            return;
        liErrors.Add(e.Data);
    }
}

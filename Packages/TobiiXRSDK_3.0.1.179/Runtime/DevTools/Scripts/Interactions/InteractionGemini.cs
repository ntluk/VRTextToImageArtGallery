using Tobii.G2OM;
using UnityEngine;

public class InteractionGemini : MonoBehaviour, IGazeFocusable, IZodiac
{
    private Renderer geminiRenderer;
    private GameObject[] stars = new GameObject[17];
    private GameObject currentStar = null;
    private GameObject menuStatus;
    public GameObject zodiacBackground;
    private GameObject gazeVisualizer;
    public GameObject flipPage;
    private LineRenderer lineRendererGaze;
    public GameObject line_1_2;
    public GameObject line_2_3;
    public GameObject line_2_4;
    public GameObject line_4_5;
    public GameObject line_5_6;
    public GameObject line_5_7;
    public GameObject line_2_12;
    public GameObject line_8_9;
    public GameObject line_9_10;
    public GameObject line_10_11;
    public GameObject line_10_12;
    public GameObject line_10_13;
    public GameObject line_13_14;
    public GameObject line_13_15;
    public GameObject line_15_16;
    public GameObject line_16_17;
    private LineRenderer lineRenderer_1_2;
    private LineRenderer lineRenderer_2_3;
    private LineRenderer lineRenderer_2_4;
    private LineRenderer lineRenderer_4_5;
    private LineRenderer lineRenderer_5_6;
    private LineRenderer lineRenderer_5_7;
    private LineRenderer lineRenderer_2_12;
    private LineRenderer lineRenderer_8_9;
    private LineRenderer lineRenderer_9_10;
    private LineRenderer lineRenderer_10_11;
    private LineRenderer lineRenderer_10_12;
    private LineRenderer lineRenderer_10_13;
    private LineRenderer lineRenderer_13_14;
    private LineRenderer lineRenderer_13_15;
    private LineRenderer lineRenderer_15_16;
    private LineRenderer lineRenderer_16_17;
    public bool isSelected = false;
    public bool isFirst = false;
    public bool isFinished = false;
    public bool isLastSelected = false;

    void Start()
    {
        InitGameObjects();
        InitRenderers();
        InitLineRendererStarPosition();
    }

    public void InitGameObjects()
    {
        for (int i = 1; i <= 17; i++)
        {
            stars[i - 1] = GameObject.Find($"StarBoundMesh/Gemini/Star{i}");
        }
        menuStatus = GameObject.Find("MenuStatus");
        gazeVisualizer = GameObject.Find("GazeUtilityMenu/Offset/GazeVisualizer");
    }

    public void InitRenderers()
    {
        geminiRenderer = GetComponent<Renderer>();
        lineRendererGaze = gazeVisualizer.GetComponent<LineRenderer>();
        lineRendererGaze.enabled = false;
        lineRenderer_1_2 = line_1_2.GetComponent<LineRenderer>();
        lineRenderer_2_3 = line_2_3.GetComponent<LineRenderer>();
        lineRenderer_2_4 = line_2_4.GetComponent<LineRenderer>();
        lineRenderer_4_5 = line_4_5.GetComponent<LineRenderer>();
        lineRenderer_5_6 = line_5_6.GetComponent<LineRenderer>();
        lineRenderer_5_7 = line_5_7.GetComponent<LineRenderer>();
        lineRenderer_2_12 = line_2_12.GetComponent<LineRenderer>();
        lineRenderer_8_9 = line_8_9.GetComponent<LineRenderer>();
        lineRenderer_9_10 = line_9_10.GetComponent<LineRenderer>();
        lineRenderer_10_11 = line_10_11.GetComponent<LineRenderer>();
        lineRenderer_10_12 = line_10_12.GetComponent<LineRenderer>();
        lineRenderer_10_13 = line_10_13.GetComponent<LineRenderer>();
        lineRenderer_13_14 = line_13_14.GetComponent<LineRenderer>();
        lineRenderer_13_15 = line_13_15.GetComponent<LineRenderer>();
        lineRenderer_15_16 = line_15_16.GetComponent<LineRenderer>();
        lineRenderer_16_17 = line_16_17.GetComponent<LineRenderer>();
    }

    public void InitLineRendererStarPosition()
    {
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_1_2, stars[0], stars[1]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_2_3, stars[1], stars[2]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_2_4, stars[1], stars[3]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_4_5, stars[3], stars[4]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_5_6, stars[4], stars[5]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_5_7, stars[4], stars[6]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_2_12, stars[1], stars[11]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_8_9, stars[7], stars[8]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_9_10, stars[8], stars[9]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_10_11, stars[9], stars[10]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_10_12, stars[9], stars[11]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_10_13, stars[9], stars[12]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_13_14, stars[12], stars[13]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_13_15, stars[12], stars[14]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_15_16, stars[14], stars[15]);
        InteractionHelper.SetLineRendererStarPosition(ref lineRenderer_16_17, stars[15], stars[16]);
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        if (hasFocus && gameObject.name == "Star1" && !isFinished)
        {
            stars[0].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[0], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star2" && !isFinished)
        {
            stars[1].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[1], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star3" && !isFinished)
        {
            stars[2].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[2], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star4" && !isFinished)
        {
            stars[3].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[3], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star5" && !isFinished)
        {
            stars[4].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[4], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star6" && !isFinished)
        {
            stars[5].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[5], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star7" && !isFinished)
        {
            stars[6].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[6], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star8" && !isFinished)
        {
            stars[7].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[7], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star9" && !isFinished)
        {
            stars[8].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[8], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star10" && !isFinished)
        {
            stars[9].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[9], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star11" && !isFinished)
        {
            stars[10].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[10], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star12" && !isFinished)
        {
            stars[11].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[11], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star13" && !isFinished)
        {
            stars[12].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[12], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star14" && !isFinished)
        {
            stars[13].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[13], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star15" && !isFinished)
        {
            stars[14].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[14], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star16" && !isFinished)
        {
            stars[15].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[15], typeof(InteractionGemini));
        }
        if (hasFocus && gameObject.name == "Star17" && !isFinished)
        {
            stars[16].GetComponent<InteractionGemini>().isSelected = true;
            geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
            InteractionHelper.ChangeStarSelection(gameObject, typeof(InteractionGemini));
            InteractionHelper.SetIsLast(stars[16], typeof(InteractionGemini));
        }
    }

    void Update()
    {
        if (!isFinished)
        {
            DrawStarLine();
            DrawGazeLine();
            DrawGazeLineAtMenu();
        }
    }

    public void DrawStarLine()
    {
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[0], ref stars[1], ref lineRenderer_1_2, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[1], ref stars[2], ref lineRenderer_2_3, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[1], ref stars[3], ref lineRenderer_2_4, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[3], ref stars[4], ref lineRenderer_4_5, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[4], ref stars[5], ref lineRenderer_5_6, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[4], ref stars[6], ref lineRenderer_5_7, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[1], ref stars[11], ref lineRenderer_2_12, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[7], ref stars[8], ref lineRenderer_8_9, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[8], ref stars[9], ref lineRenderer_9_10, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[9], ref stars[10], ref lineRenderer_10_11, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[9], ref stars[11], ref lineRenderer_10_12, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[9], ref stars[12], ref lineRenderer_10_13, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[12], ref stars[13], ref lineRenderer_13_14, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[12], ref stars[14], ref lineRenderer_13_15, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[14], ref stars[15], ref lineRenderer_15_16, typeof(InteractionGemini));
        InteractionHelper.HandleStarLines(ref currentStar, ref stars[15], ref stars[16], ref lineRenderer_16_17, typeof(InteractionGemini));
    }

    public void DrawGazeLine()
    {
        foreach (GameObject star in stars)
        {
            if (star.GetComponent<InteractionGemini>().isLastSelected)
            {
                InteractionHelper.SetLineRendererGazePosition(ref lineRendererGaze, star, gazeVisualizer);
                InteractionHelper.SetIsFirst(star, typeof(InteractionGemini));

                if (!isFinished)
                {
                    InteractionHelper.ChangeScriptComponentStatus(false, typeof(InteractionGemini));
                }
            }
        }

        ZodiacCompleted();
    }

    public void ZodiacCompleted()
    {
        if (lineRenderer_1_2.enabled &&
           lineRenderer_2_3.enabled &&
           lineRenderer_2_4.enabled &&
           lineRenderer_4_5.enabled &&
           lineRenderer_5_6.enabled &&
           lineRenderer_5_7.enabled &&
           lineRenderer_2_12.enabled &&
           lineRenderer_8_9.enabled &&
           lineRenderer_9_10.enabled &&
           lineRenderer_10_11.enabled &&
           lineRenderer_10_12.enabled &&
           lineRenderer_10_13.enabled &&
           lineRenderer_13_14.enabled &&
           lineRenderer_13_15.enabled &&
           lineRenderer_15_16.enabled &&
           lineRenderer_16_17.enabled)
        {
            lineRendererGaze.enabled = false;
            currentStar = null;

            foreach (GameObject star in stars)
            {
                geminiRenderer = star.GetComponent<Renderer>();
                geminiRenderer.material.SetColor(Shader.PropertyToID("_BaseColor"), Color.green);
            }
  
            InteractionHelper.ChangeScriptComponentStatus(true, typeof(InteractionGemini));
            InteractionHelper.ResetPreviousStars();
            if (!isFinished)
            {
                flipPage.GetComponent<FlipPage>().ChangePageContent(false, typeof(InteractionGemini));
                InteractionHelper.PlayFadeInSound();
                StartCoroutine(InteractionHelper.FadeInZodiac(zodiacBackground));
                Invoke(nameof(UpdateColorAfterCoroutine), 10.0f);
            }
            isFinished = true;
        }
    }

    public void UpdateColorAfterCoroutine()
    {
        StopAllCoroutines();
        Color _tmpColor = zodiacBackground.GetComponent<SpriteRenderer>().color;
        zodiacBackground.GetComponent<SpriteRenderer>().color = new Color(_tmpColor.r, _tmpColor.g, _tmpColor.b, 255);
    }

    public void DrawGazeLineAtMenu()
    {
        InteractionHelper.DrawGazeLineAtMenu(ref lineRendererGaze, menuStatus, currentStar, gazeVisualizer);
    }
}

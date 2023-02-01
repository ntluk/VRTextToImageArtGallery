using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Tobii.XR;
using TMPro;


// GalleryManager 
public class GalleryManager : MonoBehaviour
{
    public List<GameObject> pictureFrames = new List<GameObject>();
    public List<GameObject> picturePool = new List<GameObject>();
    public List<GameObject> pictureSelection = new List<GameObject>();
    private List<String> flickeringLights = new List<String>();
    private List<String> focusedBefore = new List<String>();

    public GameObject pictureF_a;
    public GameObject pictureF_b;
    public GameObject pictureF_c;
    public GameObject pictureF_d;
    public GameObject pictureL_a;
    public GameObject pictureL_b;
    public GameObject pictureL_c;
    public GameObject pictureR_a;
    public GameObject pictureR_b;
    public GameObject pictureR_c;
    public GameObject pictureB_a;
    public GameObject pictureB_b;
    public GameObject pictureB_c;
    public GameObject pictureB_d;

    public GameObject personalized;
    public GameObject personalPrefab;

    private GameObject focused;
    private string focusedPictureFrame;
    private String finalPrompt = "";
    private String focusedLast = "";
    private String changedLast = "";
    private int swapCount = 0;
    private int focusCount = 0;
    private bool isFlickering = false;
    private bool sent = false;
    private bool userIsOriented = false;
    private bool removeFrames = false;
    private bool cooldown = false;

    private System.Random rnd;
    private float timeDelay;
    private int focusTime = 0;
    private int remainingPictureFrames = 14;

    private UDPSend sender = new UDPSend();

    // Start is called before the first frame update
    void Start()
    {
        sender.Start();
        rnd = new System.Random();

        SetupRoom();
        SelectFromPool();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
            ManageInput();
        
        if (userIsOriented == true)
            CheckEyeFocus();

        if (removeFrames && !cooldown)
            StartCoroutine(RemovePictureFrames());
        

        //if(remainingPictureFrames < 4)
        //   SendPrompt();
    }

    private void SelectFromPool()
    {
        for (int i = 0; i < pictureSelection.Count; i++)
        {
            int pos = rnd.Next(0, picturePool.Count);
            pictureSelection[i] = picturePool[pos];
            picturePool.Remove(picturePool[pos]);
        }
    }

    private void SetupRoom()
    {
        for (int i = 0; i < pictureFrames.Count; i++)
        {
            int pos = rnd.Next(0, picturePool.Count);
            Instantiate(picturePool[pos], pictureFrames[i].transform);
            Destroy(pictureFrames[i].transform.GetChild(0).gameObject);
            picturePool.Remove(picturePool[pos]);
        }
    }
    private void CheckEyeFocus()
    {
        // Check for focused objects.
        if (TobiiXR.FocusedObjects.Count > 0)//&& pictureSelection.Count > 0
        {
            
            focused = TobiiXR.FocusedObjects[0].GameObject;
            //Debug.Log(focused.transform.parent.parent.parent.name);
            if (focusedLast.Contains(focused.name))
                focusTime++;
            focusedLast += focused.name;
            
            int pos = rnd.Next(0, pictureSelection.Count);

            if (focused.transform.parent.parent.parent != null)
                focusedPictureFrame = focused.transform.parent.parent.parent.name;


            switch (focusedPictureFrame)
            {
                case "PictureF_a":
                    if (pictureSelection.Count < 1)
                        RemovePictureFrame(pictureF_a, pictureB_d);
                    else if (!changedLast.Equals("F_a"))
                        SwapPicture("F_a", pictureB_d, pos);
                    break;

                case "PictureF_b":
                    if (pictureSelection.Count < 1)
                        RemovePictureFrame(pictureF_b, pictureB_c);
                    else if (!changedLast.Equals("F_b"))
                        SwapPicture("F_b", pictureB_c, pos);
                    break;

                case "PictureF_c":
                    if (pictureSelection.Count < 1)
                        RemovePictureFrame(pictureF_c, pictureB_b);
                    else if (!changedLast.Equals("F_c"))
                        SwapPicture("F_c", pictureB_b, pos);
                    break;

                case "PictureF_d":
                    if (pictureSelection.Count < 1)
                        RemovePictureFrame(pictureF_d, pictureB_a);
                    else if (!changedLast.Equals("F_d"))
                        SwapPicture("F_d", pictureB_a, pos);
                    break;

                case "PictureL_a":
                    if (pictureSelection.Count < 1)
                        RemovePictureFrame(pictureL_a, pictureR_c);
                    else if (!changedLast.Equals("L_a"))
                        SwapPicture("L_a", pictureR_c, pos);
                    break;

                case "PictureL_b":
                    if (pictureSelection.Count < 1)
                        RemovePictureFrame(pictureL_b, pictureR_b);
                    else if (!changedLast.Equals("L_b"))
                        SwapPicture("L_b", pictureR_b, pos);
                    break;

                case "PictureL_c":
                    if (pictureSelection.Count < 1)
                        RemovePictureFrame(pictureL_c, pictureR_a);
                    else if (!changedLast.Equals("L_c"))
                        SwapPicture("L_c", pictureR_a, pos);
                    break;

                case "PictureR_a":
                    if (pictureSelection.Count < 1)
                        RemovePictureFrame(pictureR_a, pictureL_c);
                    else if (!changedLast.Equals("R_a"))
                        SwapPicture("R_a", pictureL_c, pos);
                    break;

                case "PictureR_b":
                    if (pictureSelection.Count < 1)
                        RemovePictureFrame(pictureR_b, pictureL_b);
                    else if (!changedLast.Equals("R_b"))
                        SwapPicture("R_b", pictureL_b, pos);
                    break;

                case "PictureR_c":
                    if (pictureSelection.Count < 1)
                        RemovePictureFrame(pictureR_c, pictureL_a);
                    else if (!changedLast.Equals("R_c"))
                        SwapPicture("R_c", pictureL_a, pos);
                    break;

                case "PictureB_a":
                    if (pictureSelection.Count < 1)
                        RemovePictureFrame(pictureB_a, pictureF_d);
                    else if (!changedLast.Equals("B_a"))
                        SwapPicture("B_a", pictureF_d, pos);
                    break;

                case "PictureB_b":
                    if (pictureSelection.Count < 1)
                        RemovePictureFrame(pictureB_b, pictureF_c);
                    else if (!changedLast.Equals("B_b"))
                        SwapPicture("B_b", pictureF_c, pos);
                    break;

                case "PictureB_c":
                    if (pictureSelection.Count < 1)
                        RemovePictureFrame(pictureB_c, pictureF_b);
                    else if (!changedLast.Equals("B_c"))
                        SwapPicture("B_c", pictureF_b, pos);
                    break;

                case "PictureB_d":
                    if (pictureSelection.Count < 1)
                        RemovePictureFrame(pictureB_d, pictureF_a);
                    else if (!changedLast.Equals("B_d"))
                        SwapPicture("B_d", pictureF_a, pos);
                    break;
            }

            if (focusedBefore.Contains(focused.name) && IsStillInFocus() && !sent)
            {
                if (!finalPrompt.Contains(focused.name) && !focused.name.Contains("(Clone)"))
                    finalPrompt += focused.name +", ";
                if (!finalPrompt.Contains(focused.GetComponent<Text>().text))
                    finalPrompt += focused.GetComponent<Text>().text + ", ";
                //Debug.Log(finalPrompt);
            }

            focusedBefore.Add(focused.name);
        }
    }

    private void SwapPicture(String inFocus, GameObject swapTarget, int picturePosInSelection)
    {
        Debug.Log("swapping picture");
        GameObject pictureToSet = pictureSelection[picturePosInSelection];

        if(swapTarget != null)
        {
            Instantiate(pictureToSet, swapTarget.transform);
            Destroy(swapTarget.transform.GetChild(0).gameObject);
            pictureSelection.Remove(pictureToSet);
        }
       
        // ChangeLable(swapTarget, pictureToSet);
        changedLast = inFocus;
        swapCount++;

        
        //CheckSwapCount(swapTarget);
    }

    private void RemovePictureFrame(GameObject frameInFocus, GameObject swapTarget)
    {
        //if (removeFrames && pictureSelection.Count < 1 && pictureFrames.Count > 2)
        //{
        //    swapTarget.SetActive(false);
        //    frameInFocus.SetActive(false);
        //    pictureFrames.Remove(swapTarget);
        //    pictureFrames.Remove(frameInFocus);
        //}

    }
    private void CheckSwapCount(GameObject swapTarget)
    {
        switch (swapCount)
        {
            case 3:
                // start flicker on first fade-out-side
               
                //StartCoroutine(FlickerLight(swapTarget));
                break;

            case 6:
                //StartCoroutine(FlickerLight(swapTarget));
                // start fading out frames
                //if (isFlickering && flickeringLights.Contains(swapTarget.name))
                //    swapTarget.transform.parent.gameObject.SetActive(false);
                
                break;

            case 7:
                //StartCoroutine(FlickerLight(swapTarget));
                // start fading out frames
                //if (isFlickering && flickeringLights.Contains(swapTarget.name))
                //    swapTarget.transform.parent.gameObject.SetActive(false);
                break;

            case 8:
                //StartCoroutine(FlickerLight(swapTarget));
                // start fading out frames
                //if (isFlickering && flickeringLights.Contains(swapTarget.name))
                //    swapTarget.transform.parent.gameObject.SetActive(false);
                break;

            case 9:
                
                //StartCoroutine(FlickerLight(swapTarget));
                //// start fading out frames
                //if (isFlickering && flickeringLights.Contains(swapTarget.name))
                //    swapTarget.transform.parent.gameObject.SetActive(false);
               
                break;

            //case 10:
            //    StartCoroutine(FlickerLight(swapTarget));
            //    // start fading out frames
            //    if (isFlickering && flickeringLights.Contains(swapTarget.name))
            //        swapTarget.transform.parent.gameObject.SetActive(false);
            //    break;

            //case 11:
            //    StartCoroutine(FlickerLight(swapTarget));
            //    // start fading out frames
            //    if (isFlickering && flickeringLights.Contains(swapTarget.name))
            //        swapTarget.transform.parent.gameObject.SetActive(false);
            //    break;

            case 20:
                //gen img
                //gameObject.SetActive(false);
                //personalized.SetActive(true);
                break;
        }

        //if (pictureSelection.Count < 1)
        //{
        //    gameObject.SetActive(false);
        //    personalized.SetActive(true);
        //}
            

        focusCount++;
        //CheckFocusCount();
    }

    //private void CheckFocusCount()
    //{
    //    if (focusCount > 200 || pictureSelection.Count < 4)
    //    {
    //        //gameObject.SetActive(false);
    //        //personalized.SetActive(true);
    //    }
    //}

    private bool IsStillInFocus()
    {
        if (focusTime > 5 * 90)
            return true;
        else
            return false;
    }

    private void ManageInput()
    {
        if (personalized.activeSelf)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (sent)
        {
            gameObject.SetActive(false);
            personalized.SetActive(true);
            
            string[] t = finalPrompt.ToString().Split(new[] { ',' }, 2);
            string title = t[0].ToUpper();
            personalized.GetComponentInChildren<TextMeshPro>().text = title;
        }
        else if (!sent && userIsOriented)
        {
            SendPrompt();
            removeFrames = true;
        }
        else
            userIsOriented = true;
    }

    private void SendPrompt()
    {
        if (!sent)
        {
            sender.sendString(finalPrompt);
            sent = true;
        }
    }
    IEnumerator RemovePictureFrames()
    {
        cooldown = true;
        int pos = rnd.Next(0, pictureFrames.Count);

        pictureFrames[pos].SetActive(false);
        pictureFrames.Remove(pictureFrames[pos]);

        yield return new WaitForSeconds(2);
        cooldown = false;
    }

    //IEnumerator FlickerLight(GameObject swapTarget)
    //{
    //    isFlickering = true;
    //    flickeringLights.Add(swapTarget.name);

    //    swapTarget.GetComponentInChildren<Light>().enabled = false;
    //    timeDelay = rnd.Next(1, 3);
    //    yield return new WaitForSeconds(timeDelay);

    //    swapTarget.GetComponentInChildren<Light>().enabled = true;
    //    timeDelay = rnd.Next(1, 3);
    //    yield return new WaitForSeconds(timeDelay);
    //}

    //private void ChangeLable(GameObject swapTarget, GameObject pictureToSet)
    //{
    //    swapTarget.GetComponentInChildren<TextMeshPro>().text = pictureToSet.name;
    //}

}


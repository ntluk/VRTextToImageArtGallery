using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private GameObject personalized;
    private GameObject prefab;

    private GameObject focused;
    private String finalPrompt = "";
    private String focusedLast = "";
    private String changedLast = "";
    private int swapCount = 0;
    private int focusCount = 0;
    private bool isFlickering = false;

    private System.Random rnd;
    private float timeDelay;
    private int focusTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();

        SelectFromPool();
        SetupRoom();
    }

    // Update is called once per frame
    void Update()
    {
        CheckEyeFocus();
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
            Instantiate(pictureSelection[i], pictureFrames[i].transform);
            Destroy(pictureFrames[i].transform.GetChild(0).gameObject);
        }
    }
    private void CheckEyeFocus()
    {
        // Check for focused objects.
        if (TobiiXR.FocusedObjects.Count > 0 && pictureSelection.Count > 0)
        {
            focused = TobiiXR.FocusedObjects[0].GameObject;
            Debug.Log(focused.transform.parent.name);
            if (focused.name.Equals(focusedLast))
                focusTime++;

            int pos = rnd.Next(0, pictureSelection.Count);

            switch (focused.transform.parent.name)
            {
                case "PictureF_a":
                    if (!changedLast.Equals("F_a"))
                        SwapPicture("F_a", pictureB_d, pos);
                    break;

                case "PictureF_b":
                    if (!changedLast.Equals("F_b"))
                        SwapPicture("F_b", pictureB_c, pos);
                    break;

                case "PictureF_c":
                    if (!changedLast.Equals("F_c"))
                        SwapPicture("F_c", pictureB_b, pos);
                    break;

                case "PictureF_d":
                    if (!changedLast.Equals("F_d"))
                        SwapPicture("F_d", pictureB_a, pos);
                    break;

                case "PictureL_a":
                    if (!changedLast.Equals("L_a"))
                        SwapPicture("L_a", pictureR_c, pos);
                    break;

                case "PictureL_b":
                    if (!changedLast.Equals("L_b"))
                        SwapPicture("L_b", pictureR_b, pos);
                    break;

                case "PictureL_c":
                    if (!changedLast.Equals("L_c"))
                        SwapPicture("L_c", pictureR_a, pos);
                    break;

                case "PictureR_a":
                    if (!changedLast.Equals("R_a"))
                        SwapPicture("R_a", pictureL_c, pos);
                    break;

                case "PictureR_b":
                    if (!changedLast.Equals("R_b"))
                        SwapPicture("R_b", pictureL_b, pos);
                    break;

                case "PictureR_c":
                    if (!changedLast.Equals("R_c"))
                        SwapPicture("R_c", pictureL_a, pos);
                    break;

                case "PictureB_a":
                    if (!changedLast.Equals("B_a"))
                        SwapPicture("B_a", pictureF_d, pos);
                    break;

                case "PictureB_b":
                    if (!changedLast.Equals("B_b"))
                        SwapPicture("B_b", pictureF_c, pos);
                    break;

                case "PictureB_c":
                    if (!changedLast.Equals("B_c"))
                        SwapPicture("B_c", pictureF_b, pos);
                    break;

                case "PictureB_d":
                    if (!changedLast.Equals("B_d"))
                        SwapPicture("B_d", pictureF_a, pos);
                    break;
            }

            if (focusedBefore.Contains(focused.name) || IsStillInFocus())
            {
                if (!finalPrompt.Contains(focused.name))
                    finalPrompt += focused.name; // change to section names and styles
                Debug.Log(finalPrompt);
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
            Instantiate(pictureToSet, swapTarget.transform.parent);
            Destroy(swapTarget);
            pictureSelection.Remove(pictureToSet);
        }
       
        // ChangeLable(swapTarget, pictureToSet);
        changedLast = inFocus;
        swapCount++;

        //CheckSwapCount(swapTarget);
    }

    private void CheckSwapCount(GameObject swapTarget)
    {
        switch (swapCount)
        {
            case 3:
                // start flicker on first fade-out-side
                StartCoroutine(FlickerLight(swapTarget));
                break;

            case 6:
                StartCoroutine(FlickerLight(swapTarget));
                // start fading out frames
                if (isFlickering && flickeringLights.Contains(swapTarget.name))
                    swapTarget.transform.parent.gameObject.SetActive(false);
                break;

            case 7:
                StartCoroutine(FlickerLight(swapTarget));
                // start fading out frames
                if (isFlickering && flickeringLights.Contains(swapTarget.name))
                    swapTarget.transform.parent.gameObject.SetActive(false);
                break;

            case 8:
                StartCoroutine(FlickerLight(swapTarget));
                // start fading out frames
                if (isFlickering && flickeringLights.Contains(swapTarget.name))
                    swapTarget.transform.parent.gameObject.SetActive(false);
                break;

            case 9:
                StartCoroutine(FlickerLight(swapTarget));
                // start fading out frames
                if (isFlickering && flickeringLights.Contains(swapTarget.name))
                    swapTarget.transform.parent.gameObject.SetActive(false);
                break;

            case 10:
                StartCoroutine(FlickerLight(swapTarget));
                // start fading out frames
                if (isFlickering && flickeringLights.Contains(swapTarget.name))
                    swapTarget.transform.parent.gameObject.SetActive(false);
                break;

            case 11:
                StartCoroutine(FlickerLight(swapTarget));
                // start fading out frames
                if (isFlickering && flickeringLights.Contains(swapTarget.name))
                    swapTarget.transform.parent.gameObject.SetActive(false);
                break;

            case 12:
                //gen img
                break;
        }

        if (personalized != null)
            gameObject.SetActive(false);

        focusCount++;
        CheckFocusCount();
    }

    private void CheckFocusCount()
    {
        if (focusCount > 200 || pictureSelection.Count < 4)
        {
            //gameObject.SetActive(false);
            //personalized.SetActive(true);
        }
    }

    private bool IsStillInFocus()
    {
        if (focusTime > 20 * 90)
            return true;
        else
            return false;
    }

    IEnumerator FlickerLight(GameObject swapTarget)
    {
        isFlickering = true;
        flickeringLights.Add(swapTarget.name);

        swapTarget.GetComponentInChildren<Light>().enabled = false;
        timeDelay = rnd.Next(1, 3);
        yield return new WaitForSeconds(timeDelay);

        swapTarget.GetComponentInChildren<Light>().enabled = true;
        timeDelay = rnd.Next(1, 3);
        yield return new WaitForSeconds(timeDelay);
    }

    //private void ChangeLable(GameObject swapTarget, GameObject pictureToSet)
    //{
    //    swapTarget.GetComponentInChildren<TextMeshPro>().text = pictureToSet.name;
    //}

}


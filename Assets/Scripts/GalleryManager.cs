using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;
using TMPro;


// GalleryManager 
public class GalleryManager : MonoBehaviour
{
    public List<GameObject> picturePool = new();
    public List<GameObject> pictureSelection = new();
    private List<String> flickeringLights = new();
    private List<String> focusedBefore = new();

    public GameObject pictureFL;
    public GameObject pictureFR;
    public GameObject pictureL;
    public GameObject pictureR;
    public GameObject pictureBL;
    public GameObject pictureBR;

    public GameObject personalized;
    public GameObject prefab;

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

    private void CheckEyeFocus()
    {
        // Check for focused objects.
        if (TobiiXR.FocusedObjects.Count > 0 && pictureSelection.Count > 0)
        {
            focused = TobiiXR.FocusedObjects[0].GameObject;

            if (focused.name.Equals(focusedLast))
                focusTime++;

            int pos = rnd.Next(0, pictureSelection.Count);

            switch (focused.name)
            {
                case "PictureFL":
                    if (!changedLast.Equals("FL"))
                        SwapPicture("FL", pictureBL, pos);
                    break;

                case "PictureFR":
                    if (!changedLast.Equals("FR"))
                        SwapPicture("FR", pictureBR, pos);
                    break;

                case "PictureL":
                    if (!changedLast.Equals("L"))
                        SwapPicture("L", pictureR, pos);
                    break;

                case "PictureR":
                    if (!changedLast.Equals("R"))
                        SwapPicture("R", pictureL, pos);
                    break;

                case "PictureBL":
                    if (!changedLast.Equals("BL"))
                        SwapPicture("BL", pictureFL, pos);
                    break;

                case "PictureBR":
                    if (!changedLast.Equals("BR"))
                        SwapPicture("BR", pictureFR, pos);
                    break;
            }

            if (focusedBefore.Contains(focused.name) || IsStillInFocus())
            {
                if (!finalPrompt.Contains(focused.name))
                    finalPrompt += focused.name;
                Debug.Log(finalPrompt);
            }

            focusedBefore.Add(focused.name);
        }
    }

    private void SwapPicture(String inFocus, GameObject swapTarget, int picturePosInSelection)
    {
        GameObject pictureToSet = pictureSelection[picturePosInSelection];

        Destroy(swapTarget);
        Instantiate(pictureToSet);
        pictureSelection.Remove(pictureToSet);

        ChangeLable(swapTarget, pictureToSet);
        changedLast = inFocus;
        swapCount++;

        CheckSwapCount(swapTarget);
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
                gameObject.SetActive(false);
                personalized.SetActive(true);
                break;
        }
        focusCount++;
        CheckFocusCount();
    }

    private void CheckFocusCount()
    {
        if (focusCount > 200 || pictureSelection.Count < 4)
        {
            gameObject.SetActive(false);
            personalized.SetActive(true);
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

    private void ChangeLable(GameObject swapTarget, GameObject pictureToSet)
    {
        swapTarget.GetComponentInChildren<TextMeshPro>().text = pictureToSet.name;
    }

}


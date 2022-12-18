using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;


// GalleryManager 
public class PictureFrameController : MonoBehaviour
{
    public List<Material> picturePool = new List<Material>();
    public List<Material> pictureSelection = new List<Material>();
    private List<String> flickeringLights = new List<String>();
  
    public GameObject pictureFL;
    public GameObject pictureFR;
    public GameObject pictureL;
    public GameObject pictureR;
    public GameObject pictureBL;
    public GameObject pictureBR;

    private GameObject focused;
    private String changedLast = "";
    private int swapCount = 0;
    private bool isFlickering = false;
    
    private System.Random rnd;
    private float timeDelay;

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
        // Check whether TobiiXR has any focused objects.
        if (TobiiXR.FocusedObjects.Count > 0 && pictureSelection.Count > 0)
        {
            focused = TobiiXR.FocusedObjects[0].GameObject;
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
        }
    }

    private void SwapPicture(String inFocus, GameObject swapTarget, int picturePosInSelection)
    {
        swapTarget.GetComponent<Renderer>().material = pictureSelection[picturePosInSelection];
        pictureSelection.Remove(pictureSelection[picturePosInSelection]);
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

            case 9:
                StartCoroutine(FlickerLight(swapTarget));
                // start fading out frames
                if (isFlickering && flickeringLights.Contains(swapTarget.name))
                    swapTarget.transform.parent.gameObject.SetActive(false);
                break;

            case 12:
                StartCoroutine(FlickerLight(swapTarget));
                // start fading out frames
                if (isFlickering && flickeringLights.Contains(swapTarget.name))
                    swapTarget.transform.parent.gameObject.SetActive(false);
                break;


        }
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


}


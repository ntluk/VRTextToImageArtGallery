using System;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;

// GalleryManager 
public class PictureFrameController : MonoBehaviour
{
    public List<Material> picturePool = new List<Material>();
    public List<Material> pictureSelection = new List<Material>();
  
    public GameObject pictureFL;
    public GameObject pictureFR;
    public GameObject pictureL;
    public GameObject pictureR;
    public GameObject pictureBL;
    public GameObject pictureBR;

    private GameObject focused;
    private String changedLast = "";
    private int swapCount = 0;
    
    private System.Random rnd;

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
        CheckSwapCount();
    }

    private void SelectFromPool()
    {
        for (int i = 0; i <= pictureSelection.Count; i++)
        {
            int pos = rnd.Next(0, picturePool.Count);
            if (picturePool[pos] != null)
            {
                pictureSelection[i] = picturePool[pos];
                picturePool.Remove(picturePool[pos]);
            }
        }
    }

    private void CheckEyeFocus()
    {
        // Check whether TobiiXR has any focused objects.
        if (TobiiXR.FocusedObjects.Count > 0)
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

    private void CheckSwapCount()
    {
        switch (swapCount)
        {
            case 3:
                // dimm lights
                break;

            case 6:
                // dimm lights further
                // start fading out frames
                break;

            case 9:
                // dimm lights further
                break;

            case 12:
                // dimm lights fully
                // fade out remeining frames
                // display personalized artpiece
                break;


        }
    }

    private void SwapPicture(String inFocus, GameObject swapTarget, int picturePosInSelection)
    {
        swapTarget.GetComponent<Renderer>().material = pictureSelection[picturePosInSelection];
        pictureSelection.Remove(pictureSelection[picturePosInSelection]);
        changedLast = inFocus;
        swapCount++;
    }


}


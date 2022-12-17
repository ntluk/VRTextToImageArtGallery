using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Tobii.G2OM;
using Tobii.XR;

public class PictureFrameController : MonoBehaviour
{
    public Camera userCamera;
    public List<Material> picturePool = new List<Material>();
    public List<Material> pictureSelection = new List<Material>();
    // public GameObject[] pictureFrames = new GameObject[2]; //6
    public GameObject pictureFL;
    public GameObject pictureFR;
    public GameObject pictureL;
    public GameObject pictureR;
    public GameObject pictureBL;
    public GameObject pictureBR;
    private GameObject focused;
    
    System.Random rnd;

    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
        SelectFromPool();
    }

    // Update is called once per frame
    void Update()
    {   // Check whether TobiiXR has any focused objects.
        if (TobiiXR.FocusedObjects.Count > 0)
        {
            focused = TobiiXR.FocusedObjects[0].GameObject;
            int pos = rnd.Next(0, pictureSelection.Count);
           
            switch (focused.name)
            {
                case "PictureFL":
                    // add cooldown if clause
                    pictureBL.GetComponent<Renderer>().material = pictureSelection[pos];
                    break;

                case "PictureFR":
                    // add cooldown if clause
                    pictureBR.GetComponent<Renderer>().material = pictureSelection[pos];
                    break;

                case "PictureL":
                    // add cooldown if clause
                    pictureR.GetComponent<Renderer>().material = pictureSelection[pos];
                    break;

                case "PictureR":
                    // add cooldown if clause
                    pictureL.GetComponent<Renderer>().material = pictureSelection[pos];
                    break;

                case "PictureBL":
                    // add cooldown if clause
                    pictureFL.GetComponent<Renderer>().material = pictureSelection[pos];
                    break;

                case "PictureBR":
                    // add cooldown if clause
                    pictureFR.GetComponent<Renderer>().material = pictureSelection[pos];
                    break;

            }
        }
       
        //foreach (GameObject frame in pictureFrames)
        //{
        //    Debug.Log(Math.Abs(Math.Abs(userCamera.transform.eulerAngles.y)));
        //    if (Math.Abs(Math.Abs(userCamera.transform.eulerAngles.y) - Math.Abs(frame.transform.eulerAngles.y)) >= 175 && Math.Abs(userCamera.transform.eulerAngles.y) <= 275)
        //    {
        //        int pos = rnd.Next(0, pictureSelection.Count);
        //        if (pictureSelection[pos] != null && pictureSelection.Count > 0)
        //        {
        //            frame.GetComponent<Renderer>().material = pictureSelection[pos];
        //            // pictureSelection.Remove(pictureSelection[pos]);
        //            frame.GetComponentInChildren<TextMeshPro>().text = frame.GetComponent<Renderer>().sharedMaterial.name;
        //        }
        //    }
        //}
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

}


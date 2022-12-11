using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PictureFrameController : MonoBehaviour
{
    public Camera userCamera;
    public List<Material> picturePool = new List<Material>();
    public List<Material> pictureSelection = new List<Material>();
    public GameObject[] pictureFrames = new GameObject[2]; //6
    
    System.Random rnd;

    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
        SelectFromPool();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject frame in pictureFrames)
        {
            Debug.Log(Math.Abs(Math.Abs(userCamera.transform.eulerAngles.y)));
            if (Math.Abs(Math.Abs(userCamera.transform.eulerAngles.y) - Math.Abs(frame.transform.eulerAngles.y)) >= 175 && Math.Abs(userCamera.transform.eulerAngles.y) <= 275)
            {
                int pos = rnd.Next(0, pictureSelection.Count);
                if (pictureSelection[pos] != null && pictureSelection.Count > 0)
                {
                    frame.GetComponent<Renderer>().material = pictureSelection[pos];
                    // pictureSelection.Remove(pictureSelection[pos]);
                    frame.GetComponentInChildren<TextMeshPro>().text = frame.GetComponent<Renderer>().sharedMaterial.name;
                }
            }
        }
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


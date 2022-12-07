using System;
using UnityEngine;

public class PictureFrameController : MonoBehaviour
{
    public Camera userCamera;
    public Material[] picturePool = new Material[6]; //50 //list
    public Material[] pictureSelection = new Material[6]; //20 //list
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
            Debug.Log(Math.Abs(Math.Abs(userCamera.transform.eulerAngles.y) - Math.Abs(frame.transform.eulerAngles.y)));
            if (Math.Abs(Math.Abs(userCamera.transform.eulerAngles.y) - Math.Abs(frame.transform.eulerAngles.y)) >= 180)
            {
                frame.GetComponent<Renderer>().material = PictureFromSelection();
                //pictureSelection.
            }
        }
    }

    private void SelectFromPool()
    {
        for (int i = 0; i <= pictureSelection.Length; i++)
        {
            pictureSelection[i] = picturePool[rnd.Next(0, picturePool.Length)];
        }
    }

    private Material PictureFromSelection()
    {   
        return pictureSelection[rnd.Next(0, pictureSelection.Length)];
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class PointerHandler : MonoBehaviour
{
    public GalleryManager gallery;
    public SteamVR_LaserPointer leftLaserPointer;
    public SteamVR_LaserPointer rightLaserPointer;
    public Material transparentMaterial;
    public Material highlightMaterial;
    public Material selectionMaterial;
    private Material formerMat;

    void Awake()
    {
        leftLaserPointer.PointerIn += PointerInside;
        leftLaserPointer.PointerOut += PointerOutside;
        leftLaserPointer.PointerClick += PointerClick;

        rightLaserPointer.PointerIn += PointerInside;
        rightLaserPointer.PointerOut += PointerOutside;
        rightLaserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.GetComponent<MeshRenderer>() != null)
        {
            //GalleryManager.instance.focusedBefore.Add(e.target.name);
            gallery.focusedBefore.Add(e.target.name);
            Debug.Log(gallery.focusedBefore);
            if (e.target.GetComponent<Text>() != null)
                gallery.styles.Add(e.target.GetComponent<Text>().text);
            Debug.Log(gallery.styles);

           
           
            if (e.target.GetComponent<MeshRenderer>().sharedMaterial == selectionMaterial)
            {
                e.target.GetComponent<MeshRenderer>().sharedMaterial = highlightMaterial;
                gallery.focusedBefore.Remove(e.target.name);
            }
            e.target.GetComponent<MeshRenderer>().sharedMaterial = selectionMaterial;
            Debug.Log("Quad was clicked");
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.GetComponent<MeshRenderer>() != null && e.target.GetComponent<MeshRenderer>().sharedMaterial != selectionMaterial)
        {
            formerMat = e.target.GetComponent<MeshRenderer>().sharedMaterial;
            e.target.GetComponent<MeshRenderer>().sharedMaterial = highlightMaterial;
            Debug.Log("Quad was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.GetComponent<MeshRenderer>() != null && e.target.GetComponent<MeshRenderer>().sharedMaterial != selectionMaterial)
        {
            
            e.target.GetComponent<MeshRenderer>().sharedMaterial = formerMat;
            Debug.Log("Quad was exited");
        }

    }
}

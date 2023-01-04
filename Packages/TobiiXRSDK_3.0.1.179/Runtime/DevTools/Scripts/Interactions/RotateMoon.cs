using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMoon : MonoBehaviour
{
    public Transform earth;
    public Transform moon;
    private float rotationSpeed = 0.3663004f;    

    void Start()
    {
        earth = GameObject.Find("Earth").transform;
        moon = GetComponent<Transform>();
    }

    void Update()
    {
        moon.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0), Space.World);
        moon.RotateAround(earth.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    private void Update()
    {
        transform.LookAt(target);
    }
}
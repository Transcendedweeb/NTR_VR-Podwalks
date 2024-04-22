using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardText : MonoBehaviour
{
    public Camera mainCamera;

    void Update()
    {
        if (mainCamera != null)
        {
            Vector3 toCamera = mainCamera.transform.position - transform.position;
            transform.forward = -toCamera.normalized;
        }
    }
}
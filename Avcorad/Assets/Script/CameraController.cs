using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    float CameraRotateX;

    float rotateMaximum = 45f;
    float rotateMinimum = -45f;



    void Update()
    {
        CameraRotateX -= Input.GetAxis("Mouse Y");
        CameraRotateX = Mathf.Clamp(CameraRotateX, rotateMinimum, rotateMaximum);

        float rotationY = transform.localEulerAngles.y;

        transform.localEulerAngles = new Vector3(CameraRotateX, rotationY, 0);

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinDeco : MonoBehaviour
{
/*    public enum SelectObject
    {
        item,
        probs
    }

    SelectObject selectObject = SelectObject.probs;*/
    public float rotateSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0, rotateSpeed * Time.deltaTime));
    }

}

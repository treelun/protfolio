using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseVisible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse Lock
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
        }

    }
}

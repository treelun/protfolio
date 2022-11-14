using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    string _str;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _str = Input.inputString;
        if (_str != null)
        {
            Debug.Log(_str + "´©¸§");
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenechanger : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
        LodingSceneContoller.LoadScene("Play");
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    float delta;

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > 2)
        {
            gameObject.SetActive(false);
        }
    }
}

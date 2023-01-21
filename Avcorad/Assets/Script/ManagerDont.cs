using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDont : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}

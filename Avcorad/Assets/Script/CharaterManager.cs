using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterManager : MonoBehaviour
{
    private static CharaterManager instance;

    public static CharaterManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Attack()
    {

    }

}

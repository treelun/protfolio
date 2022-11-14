using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEye : MonoBehaviour
{
    public Transform target;

    //enemy가 캐릭터를 따라가게 하기위한 trigger값들
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            target = other.transform;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            target = other.transform;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            target = null;
        }
    }
}

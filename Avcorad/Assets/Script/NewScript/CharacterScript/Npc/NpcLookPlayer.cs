using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcLookPlayer : MonoBehaviour
{
    public Transform Head;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Head.LookAt(other.transform);
        }
    }
}

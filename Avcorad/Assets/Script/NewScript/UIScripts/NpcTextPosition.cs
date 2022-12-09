using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTextPosition : MonoBehaviour
{
    public GameObject Npc;
    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(Npc.transform.position + new Vector3(0f, 1.8f, 0));
    }
}

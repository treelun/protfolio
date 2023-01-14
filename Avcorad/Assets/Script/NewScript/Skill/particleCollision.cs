using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("파티클 충돌");
        if (other.transform.tag == "Enemy")
        {
            other.GetComponent<MonsterEntity>().Hit(40f);
        }
    }
}

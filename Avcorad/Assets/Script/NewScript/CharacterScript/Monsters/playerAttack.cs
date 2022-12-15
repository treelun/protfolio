using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    KnightZombie zombie;
    private void Start()
    {
        zombie = FindObjectOfType<KnightZombie>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            zombie.state = LivingEntity.State.Attack;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            zombie.state = LivingEntity.State.Tracking;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInPlayer : MonoBehaviour
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
            zombie.target = other.transform;
            zombie.state = LivingEntity.State.Tracking;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            zombie.target = null;
            zombie.state = LivingEntity.State.Move;
        }
    }

}

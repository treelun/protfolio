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
            Debug.Log(zombie.target);
        }
    }

    /*    private void OnTriggerStay(Collider other)
        {
            if (other.transform.tag == "Player")
            {
                monsterEntity.target = other.transform;
                monsterEntity.state = LivingEntity.State.Tracking;
                Debug.Log(monsterEntity.target);
            }
        }*/

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            zombie.target = null;
            zombie.state = LivingEntity.State.Move;
        }
    }

}

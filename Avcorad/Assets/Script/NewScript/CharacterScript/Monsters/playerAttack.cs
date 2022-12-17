using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    MonsterEntity enemy;
    private void Start()
    {
        enemy = FindObjectOfType<MonsterEntity>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            enemy.state = LivingEntity.State.Attack;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            enemy.state = LivingEntity.State.Tracking;
        }
    }
}

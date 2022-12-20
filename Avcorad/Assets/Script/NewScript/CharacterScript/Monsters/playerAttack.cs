using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    MonsterEntity enemy;
    private void Start()
    {
        this.enemy = GetComponentInParent<MonsterEntity>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            this.enemy.state = LivingEntity.State.Attack;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            this.enemy.state = LivingEntity.State.Tracking;
        }
    }
}

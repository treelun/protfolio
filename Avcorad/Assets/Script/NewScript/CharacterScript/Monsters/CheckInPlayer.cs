using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInPlayer : MonoBehaviour
{
    MonsterEntity enemy;
    private void Start()
    {
        //enemy = FindObjectOfType<MonsterEntity>();
        this.enemy = GetComponentInParent<MonsterEntity>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" &&
            this.enemy.state != LivingEntity.State.Death)
        {
            this.enemy.target = other.transform;
            this.enemy.state = LivingEntity.State.Tracking;
        }
        else if (this.enemy.state == LivingEntity.State.Death)
        {
            this.enemy.target = null;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player" &&
            this.enemy.state != LivingEntity.State.Death)
        {
            this.enemy.target = null;
            this.enemy.state = LivingEntity.State.Move;
        }
    }

}

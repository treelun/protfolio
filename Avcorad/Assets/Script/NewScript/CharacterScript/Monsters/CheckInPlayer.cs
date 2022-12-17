using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInPlayer : MonoBehaviour
{
    MonsterEntity enemy;
    private void Start()
    {
        enemy = FindObjectOfType<MonsterEntity>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" &&
            enemy.state != LivingEntity.State.Death)
        {
            enemy.target = other.transform;
            enemy.state = LivingEntity.State.Tracking;
        }
        else if (enemy.state == LivingEntity.State.Death)
        {
            enemy.target = null;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player" &&
            enemy.state != LivingEntity.State.Death)
        {
            enemy.target = null;
            enemy.state = LivingEntity.State.Move;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    MonsterEntity monsterEntity;

    private void Start()
    {
        monsterEntity = FindObjectOfType<MonsterEntity>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<PlayerEntity>().Hit(monsterEntity.AttackForce);
        }
        else if (other.transform.tag == "EnemyDeath")
        {
            monsterEntity.enemyState = MonsterEntity.EnemyState.Move;
        }
    }
}

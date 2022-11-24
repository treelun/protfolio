/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackDamage;
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            PlayerMove player = other.GetComponent<PlayerMove>();
            
            //player.DamageCharacter(attackDamage);
            
            Debug.Log("플레이어 공격~!" + attackDamage);
        }
    }
}
*/
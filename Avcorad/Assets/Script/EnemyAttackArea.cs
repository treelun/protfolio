/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    Animator anima;

    public BoxCollider AttackPoint;
    
    
    AudioSource audiosource;
    EnemyController enemyController;

    bool attackReady;
    float AttackSpeed = 5f;
    float AttackDelay;
    public bool isAttack;
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponentInParent<Animator>();
        audiosource = GetComponent<AudioSource>();
        enemyController = GetComponentInParent<EnemyController>();
    }

*//*    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            anima.SetBool("isRun", false);
            anima.SetBool("isWalk", false);
            if (!other.GetComponentInChildren<Weapon>().isHit && !enemyController.isDeath && !isAttack)
            {
                Debug.Log("АјАн");
                StartCoroutine(Attack());
                anima.SetTrigger("attack");
                audiosource.Play();
            }

        }
    }*//*


    IEnumerator Attack()
    {

        AttackPoint.enabled = true;
        isAttack = true;
        
        yield return new WaitForSeconds(0.7f);

        AttackPoint.enabled = false;

        yield return new WaitForSeconds(4f);
        isAttack = false;

    }

}
*/
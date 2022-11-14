using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    WeaponData weapon;
    AudioSource audiosouce;

    public BoxCollider AttackArea;
    public ParticleSystem particleSystem;
    public bool isHit;

    private void Start()
    {
        weapon = GetComponent<WeaponScriptAble>().weaponData;
        audiosouce = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            Animator enemyani = other.GetComponent<Animator>();
            enemy.DamageCharacter(weapon.damage);
            //enemyani.SetTrigger("hitMotion");
            Debug.Log("Enemy공격" + weapon.damage);
            particleSystem.GetComponent<ParticleSystem>().Play();
            isHit = true;
            if (enemy.Hitpoint <= float.Epsilon) //float.Epsilon은 0보다 큰 가장 작은 양수의 값을 나타냄
            {
                enemyani.SetTrigger("death");
            }
        }
        else
        {
            isHit = false;
        }
    }

    public void PlayerMeleeAttack()
    {
        StopCoroutine(Attack());
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        AttackArea.enabled = true;
        audiosouce.Play();

        yield return new WaitForSeconds(0.4f);

        AttackArea.enabled = false;
        audiosouce.Stop();

    }

}

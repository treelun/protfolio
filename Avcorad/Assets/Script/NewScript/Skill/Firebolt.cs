using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt : Skill
{
    RaycastHit hit;

    public GameObject projectiles;

    public Transform spawnPosition;

    public float speed = 1000;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        SkillDamage = 30f;
        needMp = 10f;
        coolTime = 5f;
        needLevel = 15;
    }

    public override void useSkill()
    {
        
        if (Physics.Raycast(spawnPosition.position, spawnPosition.forward, out hit, 50f) && !isUse) //Finds the point where you click with the mouse
        {
            if (hit.transform.tag != "Ground")
            {
                GameManager.Instance.mainPlayer.playerData.animator.SetTrigger("Casting");
                Debug.Log("파이어볼트 발사!!");
                GameObject projectile = Instantiate(projectiles, spawnPosition.position, Quaternion.identity) as GameObject; //Spawns the selected projectile
                projectile.transform.LookAt(hit.point); //Sets the projectiles rotation to look at the point clicked
                projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed); //Set the speed of the projectile by applying force to the rigidbody
                StartCoroutine(useSkillCoroutine());
                GameManager.Instance.mainPlayer.playerData.Mp -= needMp;
                //데미지 주는법 -> hit된놈의 Getcomponent<LivingEntity>().hit(데미지)를 입력해서 데미지를 주자
            }
        }
        base.useSkill();
    }

    IEnumerator useSkillCoroutine()
    {
        isUse = true;
        yield return new WaitForSeconds(5f);
        isUse = false;
    }

}

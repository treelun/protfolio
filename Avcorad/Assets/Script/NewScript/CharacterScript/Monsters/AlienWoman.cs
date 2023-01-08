using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class AlienWoman : MonsterEntity
{

    RaycastHit hit;

    public GameObject projectiles;

    public Transform spawnPosition;

    public Transform rayPosition;
    public float speed = 1000;

    float delta2;

    [SerializeField]
    /// a feedback to be played when the cube lands
    private MMFeedbacks LandingFeedbacks;

    public override void Update()
    {
        base.Update();

        if (enemyState == EnemyState.Tracking)
        {
            useSkill();
        }

 
    }
    public void useSkill()
    {
        delta2 += Time.deltaTime;
        if (Physics.Raycast(rayPosition.position, rayPosition.forward, out hit, 50f)) //Finds the point where you click with the mouse
        {
            if (hit.transform.tag != "Ground" && delta2 > 10f)
            {
                animator.SetTrigger("MagicAttack");
                GameObject projectile = Instantiate(projectiles, spawnPosition.position, Quaternion.identity) as GameObject; //Spawns the selected projectile
                projectile.transform.LookAt(hit.point); //Sets the projectiles rotation to look at the point clicked
                projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed); //Set the speed of the projectile by applying force to the rigidbody
                                                                                                     //데미지 주는법 -> hit된놈의 Getcomponent<LivingEntity>().hit(데미지)를 입력해서 데미지를 주자

                delta2 = 0;
            }
        }
    }

    public void JumpAttackEnd()
    {
        LandingFeedbacks?.PlayFeedbacks();
    }

    
}

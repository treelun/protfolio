using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class LightingStrike : Skill
{
    RaycastHit hit;

    public GameObject projectiles;

    public Transform spawnPosition;

    public float speed = 1000;

    [SerializeField]
    /// a feedback to be played when the cube lands
    private MMFeedbacks LightingFeedbacks;

    private void Start()
    {
        Init();

    }
    public override void Init()
    {
        base.Init();
        SkillDamage = 30f;
        needMp = 15f;
        coolTime = 3f;
        needLevel = 20;
    }

    public override void useSkill()
    {
        
        if (Physics.Raycast(spawnPosition.position, spawnPosition.forward, out hit, 100f) && !isUse) //Finds the point where you click with the mouse
        {
            if (hit.transform.tag != "Ground")
            {
                GameManager.Instance.mainPlayer.playerData.animator.SetTrigger("Casting");
                Debug.Log("라이트닝 스트라이크 발사!!");
                GameObject projectile = Instantiate(projectiles, hit.transform.position, Quaternion.Euler(-90, 0, 0)) as GameObject; //Spawns the selected projectile
                StartCoroutine(useSkillCoroutine());
                Destroy(projectile, 3f);
                LightingFeedbacks?.PlayFeedbacks();
                GameManager.Instance.mainPlayer.playerData.Mp -= needMp;
                //데미지 주는법 -> hit된놈의 Getcomponent<LivingEntity>().hit(데미지)를 입력해서 데미지를 주자
            }
        }
        base.useSkill();
    }
    IEnumerator useSkillCoroutine()
    {
        isUse = true;
        yield return new WaitForSeconds(3f);
        isUse = false;
    }
}

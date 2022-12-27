using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class JumpAttack : Skill
{
    public GameObject projectiles;

    public Transform spawnPosition;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        SkillDamage = 40f;
        needMp = 10f;
        coolTime = 1f;
        needLevel = 5;
    }

    public override void useSkill()
    {
        
        if (!isUse)
        {
            GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Attack;
            GameManager.Instance.mainPlayer.playerData.animator.SetTrigger("JumpAttack");
            StartCoroutine(useSkillCoroutine());
            GameManager.Instance.mainPlayer.playerData.Mp -= needMp;
            Debug.Log("점프어택 실행합니다.");
        }
        base.useSkill();
    }

    IEnumerator useSkillCoroutine()
    {

        isUse = true;
        yield return new WaitForSeconds(2f);
        isUse = false;

    }
}

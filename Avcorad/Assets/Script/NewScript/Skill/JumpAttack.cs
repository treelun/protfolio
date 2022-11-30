using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : MonoBehaviour, ISkill
{
    public float SkillDamage { get  ; set  ; }
    public float needMp { get  ; set  ; }
    public float coolTime { get  ; set  ; }

    public void Init()
    {
        SkillDamage = 40f;
        needMp = 10f;
        coolTime = 10f;
    }

    public void useSkill()
    {
        GameManager.Instance.mainPlayer.playerData.animator.SetTrigger("JumpAttack");
    }


}

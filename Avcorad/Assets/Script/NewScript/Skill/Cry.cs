using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using TMPro;

public class Cry : Skill
{
    public GameObject projectiles;

    public Transform spawnPosition;

    [Header("Feedbacks")]
    [SerializeField]
    /// a feedback to be played when the jump happens
    private MMFeedbacks CryFeedbacks;

    float BuffHp;
    float BuffSta;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        BuffHp = 30f;
        BuffSta = 15f;
        needMp = 30f;
        coolTime = 8f;
        needLevel = 10;
    }

    public override void useSkill()
    {
        
        if (!isUse)
        {
            GameManager.Instance.mainPlayer.playerData.Mystate = LivingEntity.State.Attack;
            GameManager.Instance.mainPlayer.playerData.animator.SetTrigger("Buff");
            Debug.Log("버프사용!!");
            GameObject projectile = Instantiate(projectiles, spawnPosition.position, Quaternion.Euler(90, 0, 0), spawnPosition);
            CryFeedbacks?.PlayFeedbacks();
            StartCoroutine(useBuff());
            GameManager.Instance.mainPlayer.playerData.Mp -= needMp;
            Destroy(projectile, 90f);
        }
        base.useSkill();
    }

    //버프사용시 적용
    IEnumerator useBuff()
    {
        GameManager.Instance.mainPlayer.playerData.maxHp += BuffHp;
        GameManager.Instance.mainPlayer.playerData.maxSta += BuffSta;
        GameManager.Instance.mainPlayer.playerData.Hp = GameManager.Instance.mainPlayer.playerData.maxHp;
        GameManager.Instance.mainPlayer.playerData.Sta = GameManager.Instance.mainPlayer.playerData.maxSta;
        isUse = true;
        yield return new WaitForSeconds(90f);
        isUse = false;
        GameManager.Instance.mainPlayer.playerData.maxHp -= BuffHp;
        GameManager.Instance.mainPlayer.playerData.maxSta -= BuffSta;
        GameManager.Instance.mainPlayer.playerData.Hp = GameManager.Instance.mainPlayer.playerData.maxHp;
        GameManager.Instance.mainPlayer.playerData.Sta = GameManager.Instance.mainPlayer.playerData.maxSta;
    }
}

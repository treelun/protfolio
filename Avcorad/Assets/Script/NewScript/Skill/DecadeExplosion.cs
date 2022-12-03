using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class DecadeExplosion : Skill
{


    RaycastHit hit;

    public GameObject projectiles;

    public Transform spawnPosition;

    public float speed = 1000;

    [SerializeField]
    /// a feedback to be played when the cube lands
    private MMFeedbacks DecadeFeedbacks;
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        SkillDamage = 100f;
        needMp = 40f;
        coolTime = 30f;
        needLevel = 25;
    }

    public override void useSkill()
    {
        
        if (Physics.Raycast(spawnPosition.position, spawnPosition.forward, out hit, 100f) && !isUse) //Finds the point where you click with the mouse
        {
            if (hit.transform.tag != "Ground")
            {
                GameManager.Instance.mainPlayer.playerData.animator.SetTrigger("Casting");
                Debug.Log("�����̵� �ͽ��÷��� �߻�!!");
                Vector3 MasicPosition = new Vector3(hit.transform.position.x, 3, hit.transform.position.z);
                GameObject projectile = Instantiate(projectiles, MasicPosition, Quaternion.Euler(-90, 0, 0)) as GameObject; //Spawns the selected projectile
                StartCoroutine(useSkillCoroutine());
                Destroy(projectile, 3f);
                DecadeFeedbacks?.PlayFeedbacks();
                GameManager.Instance.mainPlayer.playerData.Mp -= needMp;
                //������ �ִ¹� -> hit�ȳ��� Getcomponent<LivingEntity>().hit(������)�� �Է��ؼ� �������� ����
            }

        }
        base.useSkill();
    }

    IEnumerator useSkillCoroutine()
    {

        isUse = true;
        yield return new WaitForSeconds(30f);
        isUse = false;

    }
}

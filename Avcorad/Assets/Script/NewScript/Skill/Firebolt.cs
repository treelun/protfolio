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
                Debug.Log("���̾Ʈ �߻�!!");
                GameObject projectile = Instantiate(projectiles, spawnPosition.position, Quaternion.identity) as GameObject; //Spawns the selected projectile
                projectile.transform.LookAt(hit.point); //Sets the projectiles rotation to look at the point clicked
                projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed); //Set the speed of the projectile by applying force to the rigidbody
                StartCoroutine(useSkillCoroutine());
                GameManager.Instance.mainPlayer.playerData.Mp -= needMp;
                //������ �ִ¹� -> hit�ȳ��� Getcomponent<LivingEntity>().hit(������)�� �Է��ؼ� �������� ����
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

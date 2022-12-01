using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt : MonoBehaviour,ISkill
{
    public float SkillDamage { get; set; }
    public float needMp { get; set; }
    public float coolTime { get; set; }

    RaycastHit hit;

    public GameObject projectiles;

    public Transform spawnPosition;

    public float speed = 1000;
    public void Init()
    {
        SkillDamage = 30f;
        needMp = 10f;
        coolTime = 5f;
    }

    public void useSkill()
    {
        GameManager.Instance.mainPlayer.playerData.animator.SetTrigger("Casting");
        Debug.Log("파이어볼트 발사!!");

        if (Physics.Raycast(spawnPosition.position, spawnPosition.forward, out hit, 50f)) //Finds the point where you click with the mouse
        {
            GameObject projectile = Instantiate(projectiles, spawnPosition.position, Quaternion.identity) as GameObject; //Spawns the selected projectile
            projectile.transform.LookAt(hit.point); //Sets the projectiles rotation to look at the point clicked
            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed); //Set the speed of the projectile by applying force to the rigidbody
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Weapon : MonoBehaviour, Iitem
{
    public float WeaponAttackForce { get; set; }

    public float WeaponAttackSpeed { get; set; }

    public Iitem.Type type { get ; set ; }
    public Sprite itemImage { get ; set ; }
    public string itemName { get ; set ; }
    public bool isSetEquip { get; set; }

    public CapsuleCollider capsulecollider;

    public TrailRenderer trailRenderer;

    public virtual void Init()
    {
        type = Iitem.Type.Weapon;
    }
    public virtual void useItem()
    {
        if (type == Iitem.Type.Weapon)
        {
            GameManager.Instance.mainPlayer.playerData.curWeapon = this;

            GameManager.Instance.mainPlayer.playerData.playerAttackForce += WeaponAttackForce;
            GameManager.Instance.mainPlayer.playerData.playerAttackSpeed += WeaponAttackSpeed;
            GameManager.Instance.mainPlayer.playerData.itemName = itemName;
            //Debug.Log("this is Weapon useItem");

            gameObject.transform.SetParent(GameManager.Instance.mainPlayer.playerData.WeaponSlot.transform);
            this.GetComponent<RectTransform>().position = GameManager.Instance.mainPlayer.playerData.WeaponSlot.transform.position;
            this.GetComponent<RectTransform>().rotation = GameManager.Instance.mainPlayer.playerData.WeaponSlot.transform.rotation;

            gameObject.SetActive(true);
        }
    }

    public virtual void unuseItem()
    {
        if (type == Iitem.Type.Weapon)
        {
            GameManager.Instance.mainPlayer.playerData.curWeapon = null;
            GameManager.Instance.mainPlayer.playerData.playerAttackForce -= WeaponAttackForce;
            GameManager.Instance.mainPlayer.playerData.playerAttackSpeed -= WeaponAttackSpeed;
            GameManager.Instance.mainPlayer.playerData.itemName = null;
            //Debug.Log("this is Weapon unuseItem");
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            if (other.GetComponent<MonsterEntity>().enemyState != MonsterEntity.EnemyState.Death)
            {
                other.GetComponent<MonsterEntity>().Hit(GameManager.Instance.mainPlayer.playerData.playerAttackForce + WeaponAttackForce);
                //freezeFrame?.PlayFeedbacks();
                other.GetComponent<MonsterEntity>().enemyState = MonsterEntity.EnemyState.Hit;
            }
            if (other.GetComponent<MonsterEntity>().Hp <= float.Epsilon)
            {
                other.GetComponent<MonsterEntity>().enemyState = MonsterEntity.EnemyState.Death;
            }
            StartCoroutine(Timedelay());
        }
        else if (other.transform.tag != "Enemy")
        {
            return;
        }
    }

    IEnumerator Timedelay()
    {
        Debug.Log("Timedelay Start");
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.01f);
        Time.timeScale = 1f;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour, Iitem
{
    public float WeaponAttackForce { get; set; }

    public float WeaponAttackSpeed { get; set; }

    public Iitem.Type type { get ; set ; }
    public Sprite itemImage { get ; set ; }
    public string itemName { get ; set ; }
    public bool isSetEquip { get; set; }

    public CapsuleCollider capsulecollider;

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
            other.GetComponent<MonsterEntity>().Hit(GameManager.Instance.mainPlayer.playerData.playerAttackForce + WeaponAttackForce);
            Debug.Log(GameManager.Instance.mainPlayer.playerData.playerAttackForce + WeaponAttackForce + "의 데미지를 주었습니다.");
            if (other.GetComponent<MonsterEntity>().Hp <= float.Epsilon)
            {
                other.GetComponent<MonsterEntity>().enemyState = MonsterEntity.EnemyState.Death;
            }
            
        }
        else if (other.transform.tag != "Enemy")
        {
            return;
        }
    }

}

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
    public bool isSetEquip { get ; set ; }

    public virtual void Init()
    {
        type = Iitem.Type.Weapon;
        
    }
    public virtual void useItem()
    {
        if (type == Iitem.Type.Weapon)
        {
            GameManager.Instance.mainPlayer.playerData.playerAttackForce += WeaponAttackForce;
            GameManager.Instance.mainPlayer.playerData.playerAttackSpeed += WeaponAttackSpeed;
            GameManager.Instance.mainPlayer.playerData.itemName = itemName;
            Debug.Log("this is Weapon useItem");
        }
    }

    public virtual void unuseItem()
    {
        if (type == Iitem.Type.Weapon)
        {
            GameManager.Instance.mainPlayer.playerData.playerAttackForce -= WeaponAttackForce;
            GameManager.Instance.mainPlayer.playerData.playerAttackSpeed -= WeaponAttackSpeed;
            GameManager.Instance.mainPlayer.playerData.itemName = null;
            Debug.Log("this is Weapon unuseItem");
        }
    }


}

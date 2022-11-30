using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WorldOfSword : Weapon
{
    public override void Init()
    {
        base.Init();
        WeaponAttackForce = 50;
        WeaponAttackSpeed = 1.2f;
        itemName = "세계의 검";
        isSetEquip = true;
        itemImage = GetComponent<Image>().sprite;
        Debug.Log(WeaponAttackForce);
    }

    public override void useItem()
    {
        base.useItem();
    }
    public override void unuseItem()
    {
        base.unuseItem();
    }
}

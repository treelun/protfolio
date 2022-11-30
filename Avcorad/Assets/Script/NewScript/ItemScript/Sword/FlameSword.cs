using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlameSword : Weapon
{
    public override void Init()
    {
        base.Init();
        WeaponAttackForce = 30;
        WeaponAttackSpeed = 1f;
        itemName = "불타는검";
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

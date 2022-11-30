using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SparkSword : Weapon
{
    public override void Init()
    {
        base.Init();
        WeaponAttackForce = 40;
        WeaponAttackSpeed = 1.1f;
        itemName = "Àü°Ý°Ë";
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

using UnityEngine.UI;
using UnityEngine;

public class StoneSword : Weapon
{
    public override void Init()
    {
        base.Init();
        WeaponAttackForce = 10;
        WeaponAttackSpeed = 0.8f;
        itemName = "µ¹°Ë";
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

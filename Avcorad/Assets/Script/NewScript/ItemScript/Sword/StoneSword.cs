using UnityEngine.UI;
using UnityEngine;

public class StoneSword : Weapon
{
    public override void Init()
    {
        base.Init();
        WeaponAttackForce = 10;
        WeaponAttackSpeed = 1.2f;
        itemName = "����";
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

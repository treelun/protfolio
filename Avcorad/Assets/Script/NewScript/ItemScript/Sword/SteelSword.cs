using UnityEngine.UI;
using UnityEngine;

public class SteelSword : Weapon
{
    public override void Init()
    {
        base.Init();
        WeaponAttackForce = 20;
        WeaponAttackSpeed = 0.9f;
        itemName = "Ã¶°Ë";
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

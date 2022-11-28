using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalPotion : Potion
{
    public override void Init()
    {
        base.Init();
        recoveryAmount = 20f;
        itemName = "�븻����";
        isSetEquip = false;
        itemImage = GetComponent<Image>().sprite;
        Debug.Log(recoveryAmount);
    }
}

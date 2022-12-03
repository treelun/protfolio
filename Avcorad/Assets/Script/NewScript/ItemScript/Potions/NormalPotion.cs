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
        itemName = "노말포션";
        isSetEquip = false;
        itemImage = GetComponent<Image>().sprite;
        Debug.Log(recoveryAmount);
        Healing = 10;
    }
    public override void useItem()
    {
        base.useItem();
        GameManager.Instance.mainPlayer.playerData.Hp += Healing;
    }
}

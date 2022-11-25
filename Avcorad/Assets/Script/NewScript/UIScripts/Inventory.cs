using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public float coin;
    public List<ItemInfo> inventory;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private InventorySlot[] slots;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<InventorySlot>();
    }

    void Awake()
    {
        FreshSlot();
    }

    public void FreshSlot()
    {
        int i = 0;
        for (; i < inventory.Count && i < slots.Length; i++)
        {
            slots[i].iteminfo = inventory[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].iteminfo = null;
        }
    }

    public void AddItem(ItemInfo _item)
    {
        if (inventory.Count < slots.Length)
        {
            inventory.Add(_item);
            FreshSlot();
        }
        else
        {
            print("½½·ÔÀÌ °¡µæ Â÷ ÀÖ½À´Ï´Ù.");
        }
    }

/*    public void EquipWeapon()
    {

        foreach (var item in inventory)
        {
            if (equipSlot.transform.childCount != 0 && !isEquipWeapon)
            {
                if (equipSlot.transform.GetChild(0).GetComponent<Image>().sprite == item.item.itemImage)
                {
                    GameManager.Instance.mainPlayer.playerData.curWeapon = item;
                    GameManager.Instance.mainPlayer.playerData.SetEquipAttackEntity(item);
                    isEquipWeapon = true;
                }
            }
            else if (equipSlot.transform.childCount == 0 && isEquipWeapon)
            {
                if (equipSlot.transform.GetChild(0).GetComponent<Image>().sprite == item.item.itemImage)
                {
                    GameManager.Instance.mainPlayer.playerData.curWeapon = null;
                    GameManager.Instance.mainPlayer.playerData.SetNotEquipAttackEntity(item);
                    isEquipWeapon = false;
                }
            }
        }

    }*/
}

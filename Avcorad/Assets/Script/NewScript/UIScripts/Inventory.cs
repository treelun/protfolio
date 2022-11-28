using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject SlotParent;
    [SerializeField]
    private InventorySlot[] slots;

    private void Start()
    {
        slots = SlotParent.GetComponentsInChildren<InventorySlot>();
    }
    private void Update()
    {
    }

    public void AcquireItem(Iitem _item, int _count = 1)
    {
        _item.Init();
        Debug.Log(_item.type);
        if (Iitem.Type.Weapon != _item.type)
        {
            Debug.Log("Æ÷¼ÇÀ» È¹µæ");
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    Debug.Log(slots[i].item.itemName);
                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].SetSlotcount(_count);
                        return;
                    }
                }
            }
        }
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }
}

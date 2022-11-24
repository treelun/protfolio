using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public float coin;
    public List<Item> inventory;

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
            slots[i].item = inventory[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    public void AddItem(Item _item)
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
}

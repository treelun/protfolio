using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image image;

    private ItemInfo _iteminfo;
    public ItemInfo iteminfo
    {
        get { return _iteminfo; }
        set
        {
            _iteminfo = value;
            if (_iteminfo != null)
            {
                image.sprite = iteminfo.item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}

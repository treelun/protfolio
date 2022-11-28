using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour
{
    public Iitem.Type type { get; set; }
    public Sprite itemImage { get; set; }
    public string WeaponName { get; set; }
    public bool isSetEquip { get; set; }

    public virtual void Init()
    {

    }
    public virtual void useItem()
    {

    }

    public virtual void unuseItem()
    {

    }
}

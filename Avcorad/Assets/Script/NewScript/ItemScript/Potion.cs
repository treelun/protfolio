using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour, Iitem
{
    protected float recoveryAmount { get; set; }

    public Iitem.Type type { get  ; set  ; }
    public Sprite itemImage { get  ; set  ; }
    public string itemName { get  ; set  ; }
    public bool isSetEquip { get  ; set  ; }

    public virtual void Init()
    {
        type = Iitem.Type.potion;
    }
}

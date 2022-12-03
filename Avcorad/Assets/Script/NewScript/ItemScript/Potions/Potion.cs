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

    public float Healing;

    public virtual void Init()
    {
        type = Iitem.Type.potion;
    }
    public virtual void useItem()
    {
        Debug.Log("회복되었습니다");
    }
}

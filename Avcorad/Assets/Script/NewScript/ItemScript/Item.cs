using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public enum ItemType { Weapon, Potions, Coins }
    public ItemType itemType;

    public Sprite itemImage;

    public string objectName;

    public int quantity;

    public bool stackable;

    public float AttackForce;

    public float AttackSpeed;

    public bool isEquip;
}

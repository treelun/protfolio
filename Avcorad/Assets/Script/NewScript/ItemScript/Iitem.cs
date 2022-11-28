using UnityEngine;

public interface Iitem 
{
    public enum Type
    {
        Weapon, potion, coin
    }
    public Type type { get; set; }
    public Sprite itemImage { get; set; }
    public string itemName { get; set; }

    public bool isSetEquip { get; set; }

    public virtual void Init(){}

    public virtual void useItem(){
    }
    public virtual void unuseItem()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    string _str;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _str = Input.inputString;
        if (_str != null)
        {
            Debug.Log(_str + "누름");
        }
        
    }
}


/*public class Inventory : MonoBehaviour
{
    public float coin;
    public List<ItemInfo> _inventory;

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
        for (; i < _inventory.Count && i < slots.Length; i++)
        {
            //slots[i].Iitem = _inventory[i];
        }
        for (; i < slots.Length; i++)
        {
            //slots[i].Iitem = null;
        }
    }

    public void AddItem(ItemInfo _item)
    {
        if (_inventory.Count < slots.Length)
        {
            _inventory.Add(_item);
            FreshSlot();
        }
        else
        {
            print("슬롯이 가득 차 있습니다.");
        }
    }

*//*/
}*/

//무기빼기 드래그직전의 부모가 equipslot인 경우
/*if (previousParent.name == "EquipSlot")
{
    //인벤토리list안에서
    foreach (var item in GameManager.Instance.inventory.inventory)
    {
        //드래그하는 오브젝트의 이미지와 list안의 이미지를 비교
        if (eventData.pointerDrag.GetComponent<Image>().sprite == item.item.itemImage)
        {
            //같으면 curWeapon=null해주고 아이템의 정보를 빼줌
            GameManager.Instance.mainPlayer.playerData.curWeapon = null;
            GameManager.Instance.mainPlayer.playerData.SetNotEquipAttackEntity(item);
            for (int i = 0; i < GameManager.Instance.equipWeapon._WeaponPrefab.Count; i++)
            {
                if (GameManager.Instance.equipWeapon._WeaponPrefab[i].GetComponent<ItemInfo>().item == item.item)
                {
                    GameManager.Instance.equipWeapon._WeaponPrefab[i].SetActive(false);
                }
            }
        }

    }
    Debug.Log("무기뻄");
}*/

/*for (int i = 0; i < GameManager.Instance.inventory.inventory.Count; i++)
{
    if (eventData.pointerDrag.transform.parent.name == "EquipSlot")
    {
        if (eventData.pointerDrag.GetComponent<Image>().sprite == GameManager.Instance.inventory.inventory[i].item.itemImage)
        {
            GameManager.Instance.mainPlayer.playerData.curWeapon = GameManager.Instance.inventory.inventory[i];
            GameManager.Instance.mainPlayer.playerData.SetEquipAttackEntity(GameManager.Instance.inventory.inventory[i]);

            for (int j = 0; j < GameManager.Instance.equipWeapon._WeaponPrefab.Count; j++)
            {
                if (GameManager.Instance.equipWeapon._WeaponPrefab[i].GetComponent<ItemInfo>().item == GameManager.Instance.inventory.inventory[i].item)
                {
                    GameManager.Instance.equipWeapon._WeaponPrefab[i].SetActive(true);
                }
            }
        }
    }
}*/

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
            Debug.Log(_str + "����");
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
            print("������ ���� �� �ֽ��ϴ�.");
        }
    }

*//*/
}*/

//���⻩�� �巡�������� �θ� equipslot�� ���
/*if (previousParent.name == "EquipSlot")
{
    //�κ��丮list�ȿ���
    foreach (var item in GameManager.Instance.inventory.inventory)
    {
        //�巡���ϴ� ������Ʈ�� �̹����� list���� �̹����� ��
        if (eventData.pointerDrag.GetComponent<Image>().sprite == item.item.itemImage)
        {
            //������ curWeapon=null���ְ� �������� ������ ����
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
    Debug.Log("����M");
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

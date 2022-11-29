using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour 
{
    public GameObject itemimageSlot;
    public int itemcount;
    public Iitem item;
    public GameObject EquipSlot;

    [SerializeField]
    private TextMeshProUGUI textCount;

    [SerializeField]
    private GameObject CountImage;
    
    public GameObject onClickBtn;

    /// <summary>
    /// ������ �̹��� alpha��(����) ����
    /// </summary>
    private void SetColor(float _alpha)
    {
        Color color = itemimageSlot.GetComponent<Image>().color;
        color.a = _alpha;
        itemimageSlot.GetComponent<Image>().color = color;
    }

    /// <summary>
    /// ������ ȹ��
    /// </summary>
    public void AddItem(Iitem _item, int _count = 1)
    {
        item = _item;
        Debug.Log(_item);
        //item.Init();
        itemcount = _count;
        itemimageSlot.GetComponent<Image>().sprite = _item.itemImage;
        
        Debug.Log(_item.itemImage);
        if (item.type != Iitem.Type.Weapon)
        {
            CountImage.SetActive(true);
            textCount.text = itemcount.ToString();
        }
        else
        {
            textCount.text = "0";
            CountImage.SetActive(false);
        }

        SetColor(1f);
    }

    /// <summary>
    /// ������ ���� ����
    /// </summary>
    public void SetSlotcount(int _Count)
    {
        itemcount += _Count;
        textCount.text = itemcount.ToString();

        //�������� ������ ������ �ʱ�ȭ
        if (itemcount <= 0)
        {
            ClearSlot();
        }
    }

    /// <summary>
    /// ���� �ʱ�ȭ
    /// </summary>
    private void ClearSlot()
    {
        item = null;
        itemcount = 0;
        itemimageSlot.GetComponent<Image>().sprite = null;
        SetColor(0);

        textCount.text = "0";
        CountImage.SetActive(false);
    }

    //������ư
    public void EquipBtn()
    {
        if (item != null)
        {
            if (item.type == Iitem.Type.Weapon && EquipSlot.transform.childCount == 0)
            {
                itemimageSlot.transform.SetParent(EquipSlot.transform);
                itemimageSlot.GetComponent<RectTransform>().position = EquipSlot.GetComponent<RectTransform>().position;
                item.useItem();
                
            }
            onClickBtn.SetActive(false);
        }
    }

    //������ư
    public void ClearBtn()
    {
        Debug.Log(item);
        if (item != null)
        {
            if (item.type == Iitem.Type.Weapon && transform.childCount == 0)
            {
                itemimageSlot.transform.SetParent(this.transform);
                itemimageSlot.GetComponent<RectTransform>().position = this.transform.GetComponent<RectTransform>().position;
                item.unuseItem();
            }
            onClickBtn.SetActive(false);
        }
    }
}

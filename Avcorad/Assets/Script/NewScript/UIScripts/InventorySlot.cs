using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour 
{
    private Transform canvas;
    public GameObject itemimageSlot;
    [HideInInspector]
    public int itemcount;
    public Iitem item;
    public GameObject EquipSlot;


    [SerializeField]
    private TextMeshProUGUI textCount;

    [SerializeField]
    private GameObject CountImage;

    [SerializeField]
    private GameObject onClickBtn;

    [SerializeField]
    private QuickSlot QuickSlot;


    [SerializeField]
    private GameObject SelectBtns;
    public Button btn1, btn2, btn3, btn4, btn5;

    [HideInInspector]
    public int selectedSlot;
    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
    }
    private void Start()
    {
        selectedSlot = -1;
        btn1.onClick.AddListener(() => SetQuickSlot(0));
        btn2.onClick.AddListener(() => SetQuickSlot(1));
        btn3.onClick.AddListener(() => SetQuickSlot(2));
        btn4.onClick.AddListener(() => SetQuickSlot(3));
        btn5.onClick.AddListener(() => SetQuickSlot(4));
    }
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
            ReturnToPosition();
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
            if (item.type != Iitem.Type.Weapon)
            {
                Debug.Log("��Ÿ������ ���");
                SelectBtns.SetActive(true);
                SelectBtns.transform.SetParent(canvas);
                SelectBtns.transform.SetAsLastSibling();
            }
            
        }
        else
        {
            onClickBtn.SetActive(false);
        }

    }
    public void ReturnToPosition()
    {
        itemimageSlot.transform.SetParent(this.transform);
        itemimageSlot.GetComponent<RectTransform>().position = this.transform.GetComponent<RectTransform>().position;
    }

    //������ư
    public void ClearBtn()
    {
        if (item != null)
        {
            if (transform.childCount == 0)
            {
                ReturnToPosition();
                if (item.type == Iitem.Type.Weapon)
                {
                    item.unuseItem();
                }
                
            }
            onClickBtn.SetActive(false);
        }
    }

    void SetQuickSlot(int _num)
    {
        selectedSlot = _num;
        SelectBtns.SetActive(false);
        SelectBtns.transform.SetParent(onClickBtn.transform);
        SelectBtns.GetComponent<RectTransform>().position = onClickBtn.transform.GetComponent<RectTransform>().position;
        if (selectedSlot != -1 && QuickSlot.quickSlot[selectedSlot].transform.childCount == 0)
        {
            Debug.Log(selectedSlot);
            Debug.Log(QuickSlot.quickSlot[selectedSlot].name);
            itemimageSlot.transform.SetParent(QuickSlot.quickSlot[selectedSlot].transform);
            itemimageSlot.GetComponent<RectTransform>().position = QuickSlot.quickSlot[selectedSlot].GetComponent<RectTransform>().position;
        }
        onClickBtn.SetActive(false);
    }
}

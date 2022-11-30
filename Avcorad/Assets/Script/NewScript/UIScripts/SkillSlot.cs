using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    private Transform canvas;
    public GameObject itemimageSlot;


    [SerializeField]
    private GameObject onClickBtn;

    [SerializeField]
    private QuickSlot QuickSlot;
    private ISkill skill;

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
        skill = itemimageSlot.GetComponent<ISkill>();
    }
    /// <summary>
    /// 슬롯의 이미지 alpha값(투명도) 변경
    /// </summary>
    private void SetColor(float _alpha)
    {
        Color color = itemimageSlot.GetComponent<Image>().color;
        color.a = _alpha;
        itemimageSlot.GetComponent<Image>().color = color;
    }

    //장착버튼
    public void EquipBtn()
    {
        Debug.Log(skill);
        if (skill != null)
        {
            Debug.Log("스킬 장착");
            SelectBtns.SetActive(true);
            SelectBtns.transform.SetParent(canvas);
            SelectBtns.transform.SetAsLastSibling();
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

    //해제버튼
    public void ClearBtn()
    {
        if (transform.childCount == 0)
        {
            ReturnToPosition();
        }
        onClickBtn.SetActive(false);
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

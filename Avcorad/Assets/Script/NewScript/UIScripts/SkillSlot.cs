using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MoreMountains.Feedbacks;

public class SkillSlot : MonoBehaviour
{
    private Transform canvas;
    public GameObject itemimageSlot;


    [SerializeField]
    private GameObject onClickBtn;

    [SerializeField]
    private QuickSlot QuickSlot;
    private Skill skill;

    [SerializeField]
    private GameObject SelectBtns;
    public Button btn1, btn2, btn3, btn4, btn5;

    [HideInInspector]
    public int selectedSlot;

    [SerializeField]
    private TextMeshProUGUI errorText;
    [SerializeField]
    private Image textBackGround;

    [SerializeField]
    /// a feedback to be played when the cube lands
    private MMFeedbacks TextFeedbacks;

    [SerializeField]
    private Image LockImage;

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
        skill = itemimageSlot.GetComponent<Skill>();
    }
    private void Update()
    {
        if (GameManager.Instance.mainPlayer.playerData.playerLevel >= skill.needLevel)
        {
            LockImage.gameObject.SetActive(false);
        }
    }
    //������ư
    public void EquipBtn()
    {
        Debug.Log(skill);
        if (skill != null && GameManager.Instance.mainPlayer.playerData.playerLevel >= skill.needLevel)
        {
            Debug.Log("��ų ����");
            SelectBtns.SetActive(true);
            SelectBtns.transform.SetParent(canvas);
            SelectBtns.transform.SetAsLastSibling();
        }
        else if (GameManager.Instance.mainPlayer.playerData.playerLevel < skill.needLevel)
        {
            errorText.text = "������ �����մϴ�. " + skill.needLevel + "������ �޼��� �ּ���";
            StartCoroutine(textTimer());
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
        else
        {
            Debug.Log("������ ��ϵǾ� �ֽ��ϴ�. �ٸ� ������ ������ �ּ���");

            errorText.text = "������ ��ϵǾ� �ֽ��ϴ�. �ٸ� ������ ������ �ּ���";
            StartCoroutine(textTimer());
        }
        onClickBtn.SetActive(false);
    }

    IEnumerator textTimer()
    {
        //textBackGround.enabled = true;
        TextFeedbacks?.PlayFeedbacks();
        yield return new WaitForSeconds(1f);
        //textBackGround.enabled = false;
        textBackGround.gameObject.SetActive(false);
    }
}

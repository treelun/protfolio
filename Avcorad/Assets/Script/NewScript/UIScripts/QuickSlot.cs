using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using MoreMountains.Feedbacks;

public class QuickSlot : MonoBehaviour
{

    public Button[] quickSlot;
    [SerializeField]
    private Transform Btn_parent;

    private int selectedSlot;

    [SerializeField]
    /// a feedback to be played when the cube lands
    private MMFeedbacks QuickSlotFeedbacks;
    [SerializeField]
    /// a feedback to be played when the cube lands
    private MMFeedbacks QuickSlotFeedbacks1;
    [SerializeField]
    /// a feedback to be played when the cube lands
    private MMFeedbacks QuickSlotFeedbacks2;
    [SerializeField]
    /// a feedback to be played when the cube lands
    private MMFeedbacks QuickSlotFeedbacks3;
    [SerializeField]
    /// a feedback to be played when the cube lands
    private MMFeedbacks QuickSlotFeedbacks4;

    [SerializeField]
    private TextMeshProUGUI EquiperrorText;
    [SerializeField]
    private Image EquiptextBackGround;


    bool isUseBtn;

    private void Start()
    {
        quickSlot = Btn_parent.GetComponentsInChildren<Button>();
        selectedSlot = 0;
    }
    private void Update()
    {
        TryInputNumber();
    }

    void TryInputNumber()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isUseBtn = true;
            if (isUseBtn)
            {
                SlotChange(0);
                QuickSlotFeedbacks?.PlayFeedbacks();
                isUseBtn = false;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isUseBtn = true;
            if (isUseBtn)
            {
                SlotChange(1);
                QuickSlotFeedbacks1?.PlayFeedbacks();
                isUseBtn = false;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            isUseBtn = true;
            if (isUseBtn)
            {
                SlotChange(2);
                QuickSlotFeedbacks2?.PlayFeedbacks();
                isUseBtn = false;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            isUseBtn = true;
            if (isUseBtn)
            {
                SlotChange(3);
                QuickSlotFeedbacks3?.PlayFeedbacks();
                isUseBtn = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            isUseBtn = true;
            if (isUseBtn)
            {
                SlotChange(4);
                QuickSlotFeedbacks4?.PlayFeedbacks();
                isUseBtn = false;
            }
        }
    }

    void SlotChange(int _num)
    {
        SelectedSlot(_num);
    }

    void SelectedSlot(int _num) {

        
        //선택된 슬롯
        selectedSlot = _num;
        //선택된 슬롯으로 이미지 이동

        for (int i = 0; i < GameManager.Instance.inventory.slots.Length; i++)
        {
            //Debug.Log(GameManager.Instance.inventory.slots[i].item.itemImage);
            if (quickSlot[selectedSlot].transform.childCount != 0 && GameManager.Instance.inventory.slots[i].item != null)
            {
                if (quickSlot[selectedSlot].transform.GetChild(0).GetComponent<Image>().sprite == GameManager.Instance.inventory.slots[i].item.itemImage && GameManager.Instance.inventory.slots[i].itemcount > 0)
                {
                    GameManager.Instance.inventory.slots[i].item.useItem();
                    GameManager.Instance.inventory.slots[i].SetSlotcount(-1);
                }

            }

        }
        for (int i = 0; i < GameManager.Instance.skillList.skill.Length; i++)
        {
            if (quickSlot[selectedSlot].transform.childCount != 0 && GameManager.Instance.skillList.skill[i] != null)
            {
                if (quickSlot[selectedSlot].transform.GetChild(0).GetComponent<Skill>() == GameManager.Instance.skillList.skill[i]
                    && GameManager.Instance.mainPlayer.playerData.Mp > GameManager.Instance.skillList.skill[i].needMp)
                {
                    GameManager.Instance.skillList.skill[i].useSkill();
                }
            }
        }
        
    }

}

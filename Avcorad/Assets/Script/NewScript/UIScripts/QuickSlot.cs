using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{

    public Button[] quickSlot;
    [SerializeField]
    private Transform Btn_parent;

    [SerializeField] private ISkill skill;

    private int selectedSlot;
    private float delta;
    private void Start()
    {
        quickSlot = Btn_parent.GetComponentsInChildren<Button>();
        selectedSlot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TryInputNumber();
    }

    void TryInputNumber()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SlotChange(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SlotChange(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SlotChange(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SlotChange(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SlotChange(4);
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
                else
                {
                    Debug.Log("사용 안됨");
                }

            }

        }
        for (int i = 0; i < GameManager.Instance.skillList.skill.Length; i++)
        {
            if (quickSlot[selectedSlot].transform.childCount != 0 && GameManager.Instance.skillList.skill[i] != null)
            {
                if (quickSlot[selectedSlot].transform.GetChild(0).GetComponent<ISkill>() == GameManager.Instance.skillList.skill[i])
                {
                    GameManager.Instance.skillList.skill[i].useSkill();
                }
                else
                {
                    Debug.Log("사용 안됨");
                }
            }

            
        }
        
        /*        else if (quickSlot[selectedSlot].skill != null)
                {
                    delta += Time.deltaTime;
                    if (delta > quickSlot[selectedSlot].skill.coolTime)
                    {
                        quickSlot[selectedSlot].skill.useSkill();
                    }
                }*/
    }
    
    void Execute()
    {
       //== GameManager.Instance.inventory.slots[i].item.itemImage
    }
}

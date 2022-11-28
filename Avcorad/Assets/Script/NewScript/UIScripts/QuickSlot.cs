using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    [SerializeField]
    private List<Button> buttons;
    [Space]
    public KeyCode slot1 = KeyCode.Alpha1;
    public KeyCode slot2 = KeyCode.Alpha2;
    public KeyCode slot3 = KeyCode.Alpha3;
    public KeyCode slot4 = KeyCode.Alpha4;
    public KeyCode slot5 = KeyCode.Alpha5;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(slot1))
        {
            ActionBtnClick(0);
        }
        else if (Input.GetKeyDown(slot2))
        {
            ActionBtnClick(1);
        }
        else if (Input.GetKeyDown(slot3))
        {
            ActionBtnClick(2);
        }
        else if (Input.GetKeyDown(slot4))
        {
            ActionBtnClick(3);
        }
        else if (Input.GetKeyDown(slot5))
        {
            ActionBtnClick(4);
        }
    }

/*    public void useItem(int number)
    {
        for (int j = 0; j < GameManager.Instance.inventory.inventory.Count; j++)
        {
            if (buttons[number].transform.childCount != 0)
            {
                Debug.Log(number + "번재의 자식 오브젝트 : " + buttons[number].transform.GetChild(0));
                if (buttons[number].transform.GetChild(0).GetComponent<Image>().sprite == GameManager.Instance.inventory.inventory[j].item.itemImage)
                {
                    Debug.Log("{0} 슬롯의 아이템 사용" + number);
                }
            }
        }

    }*/

    void ActionBtnClick(int btnIndex)
    {
        buttons[btnIndex].onClick.Invoke();
    }
}

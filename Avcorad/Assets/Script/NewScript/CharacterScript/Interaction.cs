using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject InterationText;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "NPC" || other.tag == "item")
        {
            InterationText.SetActive(true);
            //NPC와 상호작용 대화창 열림 & 아이템 획득 인벤토리에 추가
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("상호작용");
                GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Interaction;    //아이템획득시 상호작용 상태로 변경
                InterationText.SetActive(false);
                //item = other.gameObject.GetComponent<ItemInfo>();
                if (other.TryGetComponent<Iitem>(out var item))
                {
                    Debug.Log(item.itemName);
                    GameManager.Instance.inventory.AcquireItem(item); //인벤토리에 추가
                    other.gameObject.SetActive(false); //먹은아이템 비활성화
                    InterationText.SetActive(false);
                    StartCoroutine(Setstate());
                }
                else if (other.TryGetComponent<NpcText>(out var npc))
                {
                    InterationText.SetActive(false);
                    other.GetComponent<NpcText>().NpcTextBackGround.gameObject.SetActive(true);
                    other.GetComponent<NpcText>().ShowText(0);
                }
            }
        }

       /* if (other.tag == "item")
        {
            if (other.gameObject.GetComponent<Item>().itemType == Item.ItemType.Weapon)
            {
                item = other.gameObject.GetComponent<Weapon>();
                GameManager.Instance.inventory.AddItem(item);

            }
            else if (other.gameObject.GetComponent<Item>().itemType == Item.ItemType.Potions)
            {
                item = other.gameObject.GetComponent<Potion>();
                GameManager.Instance.inventory.AddItem(item);
                Debug.Log("포션획득");
            }


        }*/
    }
    void OnTriggerExit()
    {
        InterationText.SetActive(false);
    }
    IEnumerator Setstate()
    {
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Move;
    }
}

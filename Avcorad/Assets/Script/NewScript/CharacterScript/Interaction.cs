using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "NPC" || other.tag == "item")
        {
            GameManager.Instance.mainPlayer.InteractionText.SetActive(true);
            //NPC와 상호작용 대화창 열림 & 아이템 획득 인벤토리에 추가
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("상호작용");
                GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Interaction;    //아이템획득시 상호작용 상태로 변경
                //item = other.gameObject.GetComponent<ItemInfo>();
                if (other.TryGetComponent<Iitem>(out var item))
                {
                    Debug.Log(item.itemName);
                    GameManager.Instance.inventory.AcquireItem(item); //인벤토리에 추가
                    other.gameObject.SetActive(false); //먹은아이템 비활성화
                    StartCoroutine(Setstate());
                }
                else if (other.transform.tag == "NPC")
                {
                    other.GetComponent<NpcText>().NpcTextBackGround.gameObject.SetActive(true);
                    other.GetComponent<NpcText>().ShowText(0);
                }

            }
        }
    }
    void OnTriggerExit()
    {
        GameManager.Instance.mainPlayer.InteractionText.SetActive(false);
    }
    IEnumerator Setstate()
    {
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Move;
    }
}

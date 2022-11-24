using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    Item item;
    Weapon newWepon;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "NPC" || other.tag == "item")
        {
            Debug.Log("F키를 누르세요");
            //NPC와 상호작용 대화창 열림 & 아이템 획득 인벤토리에 추가
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("상호작용");
                GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Interaction;

                if (other.gameObject.GetComponent<ItemInfo>().item.itemType == Item.ItemType.Weapon)
                {
                    item = other.gameObject.GetComponent<ItemInfo>().item;
                    //newWepon = other.gameObject.GetComponent<Weapon>();
                    GameManager.Instance.inventory.AddItem(item);
                    //GameManager.Instance.mainPlayer.playerData.GetWeapon(newWepon);
                    other.gameObject.SetActive(false);
                    StartCoroutine(Setstate());
                }
                else if (other.gameObject.GetComponent<Item>().itemType == Item.ItemType.Potions)
                {
                    item = other.gameObject.GetComponent<Potion>();
                    GameManager.Instance.inventory.AddItem(item);
                    Debug.Log("포션획득");
                    other.gameObject.SetActive(false);
                    StartCoroutine(Setstate());
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

    IEnumerator Setstate()
    {
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Move;
    }
}

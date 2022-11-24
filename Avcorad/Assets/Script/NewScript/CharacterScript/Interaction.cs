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
            Debug.Log("FŰ�� ��������");
            //NPC�� ��ȣ�ۿ� ��ȭâ ���� & ������ ȹ�� �κ��丮�� �߰�
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("��ȣ�ۿ�");
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
                    Debug.Log("����ȹ��");
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
                Debug.Log("����ȹ��");
            }


        }*/
    }

    IEnumerator Setstate()
    {
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Move;
    }
}

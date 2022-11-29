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
            Debug.Log("FŰ�� ��������");
            InterationText.SetActive(true);
            //NPC�� ��ȣ�ۿ� ��ȭâ ���� & ������ ȹ�� �κ��丮�� �߰�
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("��ȣ�ۿ�");
                GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Interaction;    //������ȹ��� ��ȣ�ۿ� ���·� ����

                //item = other.gameObject.GetComponent<ItemInfo>();
                if (other.TryGetComponent<Iitem>(out var item))
                {
                    Debug.Log(item);
                    GameManager.Instance.inventory.AcquireItem(item); //�κ��丮�� �߰�
                    other.gameObject.SetActive(false); //���������� ��Ȱ��ȭ
                    InterationText.SetActive(false);
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

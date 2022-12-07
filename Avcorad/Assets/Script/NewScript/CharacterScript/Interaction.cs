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
            //NPC�� ��ȣ�ۿ� ��ȭâ ���� & ������ ȹ�� �κ��丮�� �߰�
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("��ȣ�ۿ�");
                GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Interaction;    //������ȹ��� ��ȣ�ۿ� ���·� ����
                //item = other.gameObject.GetComponent<ItemInfo>();
                if (other.TryGetComponent<Iitem>(out var item))
                {
                    Debug.Log(item.itemName);
                    GameManager.Instance.inventory.AcquireItem(item); //�κ��丮�� �߰�
                    other.gameObject.SetActive(false); //���������� ��Ȱ��ȭ
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

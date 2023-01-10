using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    int textcount;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "NPC" || other.tag == "item")
        {
            GameManager.Instance.mainPlayer.InteractionText.SetActive(true);
            //NPC�� ��ȣ�ۿ� ��ȭâ ���� & ������ ȹ�� �κ��丮�� �߰�
            if (Input.GetKey(KeyCode.F))
            {
                GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Interaction;    //������ȹ��� ��ȣ�ۿ� ���·� ����
                //item = other.gameObject.GetComponent<ItemInfo>();
                if (other.TryGetComponent<Iitem>(out var item))
                {
                    //Debug.Log(item.itemName);
                    GameManager.Instance.inventory.AcquireItem(item); //�κ��丮�� �߰�
                    if (item.type == Iitem.Type.Weapon)
                    {
                        other.GetComponent<Weapon>().capsulecollider.enabled = false;
                    }
                    other.gameObject.SetActive(false); //���������� ��Ȱ��ȭ
                    StartCoroutine(Setstate());
                }
                else if (other.transform.tag == "NPC")
                {
                    other.GetComponent<NpcText>().NpcTextBackGround.gameObject.SetActive(true);
                    other.GetComponent<NpcText>().ShowText(textcount);
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

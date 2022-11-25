using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DropableUI : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    private Image image;
    private RectTransform rect;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    /// <summary>
    /// ���콺 �����Ͱ� ���� ������ ���� ���� ���η� �� �� 1ȸ ȣ��
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.white;
    }
    /// <summary>
    /// ���콺 �����Ͱ� ���� ������ ���� ������ �������� �� 1ȸ ȣ��
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.gray;
    }
    /// <summary>
    /// ���� ������ ���� ���� ���ο��� ����� ���� �� 1ȸ ȣ��
    /// </summary>
    public void OnDrop(PointerEventData eventData)
    {
        DragableUI dragableUI;
        dragableUI = eventData.pointerDrag.gameObject.GetComponent<DragableUI>();
        //pointerDrag�� ���� �巡�� �ϰ� �ִ� ���(=������)
        if (transform.childCount == 0)
        {
            //�巡�� �ϰ� �ִ� ����� �θ� ���� ������Ʈ�� �����ϰ�, ��ġ�� ���� ������Ʈ ��ġ�� �����ϰ� ����
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;

            foreach (var item in GameManager.Instance.inventory.inventory)
            {
                if (eventData.pointerDrag.transform.parent.name == "EquipSlot")
                {
                    if (eventData.pointerDrag.GetComponent<Image>().sprite == item.item.itemImage && item.item.itemType == Item.ItemType.Weapon)
                    {
                        GameManager.Instance.mainPlayer.playerData.curWeapon = item;
                        GameManager.Instance.mainPlayer.playerData.SetEquipAttackEntity(item);

                        for (int i = 0; i < GameManager.Instance.equipWeapon._WeaponPrefab.Count; i++)
                        {
                            Debug.Log("�������");
                            if (GameManager.Instance.equipWeapon._WeaponPrefab[i].GetComponent<ItemInfo>().item == item.item)
                            {
                                GameManager.Instance.equipWeapon._WeaponPrefab[i].SetActive(true);
                            }
                        }
                        
                    }
                    else if (item.item.itemType == Item.ItemType.Potions)
                    {
                        dragableUI.returnToParent();
                    }
                }
            }
        }
        else
        {
            dragableUI.returnToParent();
        }
    }
}

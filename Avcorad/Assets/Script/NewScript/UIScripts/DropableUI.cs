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
    /// 마우스 포인터가 현재 아이템 슬롯 영역 내부로 들어갈 때 1회 호출
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.white;
    }
    /// <summary>
    /// 마우스 포인터가 현재 아이템 슬롯 영역을 빠져나갈 때 1회 호출
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.gray;
    }
    /// <summary>
    /// 현재 아이템 슬롯 영역 내부에서 드롭을 했을 대 1회 호출
    /// </summary>
    public void OnDrop(PointerEventData eventData)
    {
        DragableUI dragableUI;
        dragableUI = eventData.pointerDrag.gameObject.GetComponent<DragableUI>();
        //pointerDrag는 현재 드래그 하고 있는 대상(=아이템)
        if (transform.childCount == 0)
        {
            //드래그 하고 있는 대상의 부모를 현재 오브젝트로 설정하고, 위치를 현재 오브젝트 위치와 동일하게 설정
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        }
        else
        {
            dragableUI.returnToParent();
        }
    }
}

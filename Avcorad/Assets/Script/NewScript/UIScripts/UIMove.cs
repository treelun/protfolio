using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMove : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private RectTransform _parentRect;

    private Vector2 _rectBegin;
    private Vector2 _moveBegin;
    private Vector2 _moveOffset;

    private void Awake()
    {
        _parentRect = transform.parent.GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _rectBegin = _parentRect.anchoredPosition;
        _moveBegin = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _moveOffset = eventData.position - _moveBegin;
        _parentRect.anchoredPosition = _rectBegin + _moveOffset;
    }


}

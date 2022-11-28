using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class onClickScript : MonoBehaviour , IPointerClickHandler
{
    public GameObject onClickBtn;

    public void OnPointerClick(PointerEventData eventData)
    {
            onClickBtn.SetActive(true);
    }

}

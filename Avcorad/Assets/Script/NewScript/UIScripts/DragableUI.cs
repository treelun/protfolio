using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragableUI : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private Transform       canvas;           //UI가 소속되어있는 최상단의 Canvas Transform
    private Transform       previousParent;    //해당 오브젝트가 직전에 소속되어 있었던 부모 Transform
    private RectTransform   rect;             //UI위치 제어를 위한 RectTransform
    private CanvasGroup     canvasGroup;      //UI의 알파값과 상호작용 제어를 위한 CanvasGroup

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    /// <summary>
    ///  현재 오브젝트를 드래그 하기 시작할때 1회 호출
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        //드래그 직전에 소속되어 있던 부모 transform 정보 저장
        previousParent = transform.parent;

        //현재 드래그중인 UI가 화면 최상단에 출력되도록 하기 위해
        transform.SetParent(canvas);        //부모 오브젝트를 Canvas로 설정
        transform.SetAsLastSibling();       //가장 앞에 보이도록 마지막 자식으로 설정(오브젝트 순서를 맨위로 올려서 가장위에 보이게끔함)

        //드래그 가능한 오브젝트가 하나가 아닌 자식들을 가지고 있을수도 있기때문에 CanvasGroup으로 통제
        //알파값을 0.6으로 설정하고 , 관선 충돌처리가 되지 않도록 한다
        canvasGroup.alpha = 0.6f; // 현재 드래그중인 오브젝트의 alpha값을 설정해 살짝 투명하게 해줌
        canvasGroup.blocksRaycasts = false;

        //무기빼기 드래그직전의 부모가 equipslot인 경우
        if (previousParent.name == "EquipSlot")
        {
            //인벤토리list안에서
            foreach (var item in GameManager.Instance.inventory.inventory)
            {
                //드래그하는 오브젝트의 이미지와 list안의 이미지를 비교
                if (eventData.pointerDrag.GetComponent<Image>().sprite == item.item.itemImage)
                {
                    //같으면 curWeapon=null해주고 아이템의 정보를 빼줌
                    GameManager.Instance.mainPlayer.playerData.curWeapon = null;
                    GameManager.Instance.mainPlayer.playerData.SetNotEquipAttackEntity(item);
                    for (int i = 0; i < GameManager.Instance.equipWeapon._WeaponPrefab.Count; i++)
                    {
                        if (GameManager.Instance.equipWeapon._WeaponPrefab[i].GetComponent<ItemInfo>().item == item.item)
                        {
                            GameManager.Instance.equipWeapon._WeaponPrefab[i].SetActive(false);
                        }
                    }
                }

            }
            Debug.Log("무기뻄");
        }
    }
    /// <summary>
    /// 현재 오브젝트를 드래그 중일 때 매 프레임 호출
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        //현재 스크린상의 마우스 위치를 UI 위치로 설정(UI가 마우스를 쫓아다니는 상태)
        rect.position = eventData.position;

    }
    /// <summary>
    /// 현재 오브젝트의 드래그를 종료할 때 1회 호출
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        //드래그를 시작하면 부모가 canvas로 설정되기에
        //드래그를 종료할때 부모가 canvas이면 아이템슬롯이 아닌 엉뚱한곳에 감
        //드롭을 했다는 뜻이기 때문에 드래그 직전에 소속되어 있던 아이템 슬롯으로 아이템을 이동해줌
        if (transform.parent == canvas)
        {
            //마지막에 소속되어 있던 previousParent의 자식으로 설정하고, 해당 위치로 이동
            returnToParent();
        }

        //알파값을 1로 설정하고, 광선 충돌처리가 되도록 한다.
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }

    public void returnToParent()
    {
        transform.SetParent(previousParent);
        rect.position = previousParent.GetComponent<RectTransform>().position;
    }
}

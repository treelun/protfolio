using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragableUI : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private Transform       canvas;           //UI�� �ҼӵǾ��ִ� �ֻ���� Canvas Transform
    private Transform       previousParent;    //�ش� ������Ʈ�� ������ �ҼӵǾ� �־��� �θ� Transform
    private RectTransform   rect;             //UI��ġ ��� ���� RectTransform
    private CanvasGroup     canvasGroup;      //UI�� ���İ��� ��ȣ�ۿ� ��� ���� CanvasGroup

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    /// <summary>
    ///  ���� ������Ʈ�� �巡�� �ϱ� �����Ҷ� 1ȸ ȣ��
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        //�巡�� ������ �ҼӵǾ� �ִ� �θ� transform ���� ����
        previousParent = transform.parent;

        //���� �巡������ UI�� ȭ�� �ֻ�ܿ� ��µǵ��� �ϱ� ����
        transform.SetParent(canvas);        //�θ� ������Ʈ�� Canvas�� ����
        transform.SetAsLastSibling();       //���� �տ� ���̵��� ������ �ڽ����� ����(������Ʈ ������ ������ �÷��� �������� ���̰Բ���)

        //�巡�� ������ ������Ʈ�� �ϳ��� �ƴ� �ڽĵ��� ������ �������� �ֱ⶧���� CanvasGroup���� ����
        //���İ��� 0.6���� �����ϰ� , ���� �浹ó���� ���� �ʵ��� �Ѵ�
        canvasGroup.alpha = 0.6f; // ���� �巡������ ������Ʈ�� alpha���� ������ ��¦ �����ϰ� ����
        canvasGroup.blocksRaycasts = false;

    }
    /// <summary>
    /// ���� ������Ʈ�� �巡�� ���� �� �� ������ ȣ��
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        //���� ��ũ������ ���콺 ��ġ�� UI ��ġ�� ����(UI�� ���콺�� �Ѿƴٴϴ� ����)
        rect.position = eventData.position;

    }
    /// <summary>
    /// ���� ������Ʈ�� �巡�׸� ������ �� 1ȸ ȣ��
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        //�巡�׸� �����ϸ� �θ� canvas�� �����Ǳ⿡
        //�巡�׸� �����Ҷ� �θ� canvas�̸� �����۽����� �ƴ� �����Ѱ��� ��
        //����� �ߴٴ� ���̱� ������ �巡�� ������ �ҼӵǾ� �ִ� ������ �������� �������� �̵�����
        if (transform.parent == canvas)
        {
            //�������� �ҼӵǾ� �ִ� previousParent�� �ڽ����� �����ϰ�, �ش� ��ġ�� �̵�
            returnToParent();
        }

        //���İ��� 1�� �����ϰ�, ���� �浹ó���� �ǵ��� �Ѵ�.
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }

    public void returnToParent()
    {
        transform.SetParent(previousParent);
        rect.position = previousParent.GetComponent<RectTransform>().position;
    }
}

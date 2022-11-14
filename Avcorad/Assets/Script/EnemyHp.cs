using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    Camera uiCamera;
    Canvas canvas;
    RectTransform rectParent;
    RectTransform rectHp;

    //offset�� ĳ���Ϳ��� �󸶳� ����Ʈ���� ǥ������
    [HideInInspector] public Vector3 offset = Vector3.zero;
    [HideInInspector] public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        uiCamera = canvas.worldCamera;
        rectParent = canvas.GetComponent<RectTransform>();
        rectHp = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //ĳ���͸� ���󰥰��̱� ������ update�� �ƴ� Late�� ���
    private void LateUpdate()
    {
        var screenPos = Camera.main.WorldToScreenPoint(target.position + offset);

        if (screenPos.z < 0.0f)
        {
            screenPos *= -1.0f;
        }
    }
}

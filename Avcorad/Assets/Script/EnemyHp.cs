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

    //offset은 캐릭터에서 얼마나 떨어트려서 표시할지
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
    //캐릭터를 따라갈것이기 때문에 update가 아닌 Late로 사용
    private void LateUpdate()
    {
        var screenPos = Camera.main.WorldToScreenPoint(target.position + offset);

        if (screenPos.z < 0.0f)
        {
            screenPos *= -1.0f;
        }
    }
}

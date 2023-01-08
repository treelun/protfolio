using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpbarPosition : MonoBehaviour
{
    public Transform enemy;
    public Slider enemyHpSlider;
    private Canvas canvas;
    private RectTransform rectParent;
    private RectTransform rectHp;
    private Camera uiCamera;

    public Vector3 offset = Vector3.zero;

    // Update is called once per frame
    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        rectParent = canvas.GetComponent<RectTransform>();
        rectHp = this.gameObject.GetComponent<RectTransform>();
        uiCamera = canvas.worldCamera;
    }

    private void LateUpdate()
    {
        var screenPos = Camera.main.WorldToScreenPoint(enemy.transform.position + offset);

        //화면 밖으로 나갔을때 HPbar가 안보이게
        if (screenPos.z < 0.0f)
        {
            screenPos *= -1.0f;
        }
        else if (screenPos.z < 1.0f)
        {
            screenPos *= 1.0f;
        }
        var localPos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, uiCamera, out localPos);

        rectHp.localPosition = localPos;

        enemyHpSlider.value = enemy.GetComponent<MonsterEntity>().Hp / enemy.GetComponent<MonsterEntity>().maxHp;
    }
}

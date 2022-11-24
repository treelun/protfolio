/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    [SerializeField] Slider HpBar;


    public EnemyController character;

    float maxHp;

    private void Start()
    {
        maxHp = character.maxHp;
    }

    private void Update()
    {
        HpBar.value = character.Hitpoint / maxHp;
    }
}
*/
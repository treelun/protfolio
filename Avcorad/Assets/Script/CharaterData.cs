using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptalbe/CharaterData", fileName = "CharaterData")]
public class CharaterData : ScriptableObject
{
    //���� �Ŀ�
    public float AttackPower;
    //ü��
    public float startingHp;
    //���� or ���ŷ�
    public float startingMp;
    //������
    public float startingStamina;

}

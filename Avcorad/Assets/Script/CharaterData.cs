using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptalbe/CharaterData", fileName = "CharaterData")]
public class CharaterData : ScriptableObject
{
    //공격 파워
    public float AttackPower;
    //체력
    public float startingHp;
    //마나 or 정신력
    public float startingMp;
    //지구력
    public float startingStamina;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipWeapon : MonoBehaviour
{

    void equip()
    {
         GameManager.Instance.mainPlayer.playerData.SetWeapon();
    }
    //무기 이미지 바꾸기
    void SetImage()
    {

    }
    //무기 이름 바꾸기
    //무기 공격력 바꾸기
    //무기 공격속도 바꾸기
}

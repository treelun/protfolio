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
    //���� �̹��� �ٲٱ�
    void SetImage()
    {

    }
    //���� �̸� �ٲٱ�
    //���� ���ݷ� �ٲٱ�
    //���� ���ݼӵ� �ٲٱ�
}

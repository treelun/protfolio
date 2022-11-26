using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI WeaponName;
    [SerializeField] TextMeshProUGUI WeaponAttackForce;
    [SerializeField] TextMeshProUGUI WeaponAttackSpeed;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.mainPlayer.playerData.curWeapon != null)
        {
            WeaponName.text = "무기 이름 : " + GameManager.Instance.mainPlayer.playerData.curWeapon.item.objectName;
            WeaponAttackForce.text = "무기 공격력 : " + GameManager.Instance.mainPlayer.playerData.curWeapon.item.AttackForce;
            WeaponAttackSpeed.text = "무기 공격속도 : " + GameManager.Instance.mainPlayer.playerData.curWeapon.item.AttackSpeed;
        }
        else
        {
            WeaponName.text = "무기 이름 : ";
            WeaponAttackForce.text = "무기 공격력 : ";
            WeaponAttackSpeed.text = "무기 공격속도 : ";
        }
        
    }
}

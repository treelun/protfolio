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
            WeaponName.text = "���� �̸� : " + GameManager.Instance.mainPlayer.playerData.curWeapon.item.objectName;
            WeaponAttackForce.text = "���� ���ݷ� : " + GameManager.Instance.mainPlayer.playerData.curWeapon.item.AttackForce;
            WeaponAttackSpeed.text = "���� ���ݼӵ� : " + GameManager.Instance.mainPlayer.playerData.curWeapon.item.AttackSpeed;
        }
        else
        {
            WeaponName.text = "���� �̸� : ";
            WeaponAttackForce.text = "���� ���ݷ� : ";
            WeaponAttackSpeed.text = "���� ���ݼӵ� : ";
        }
        
    }
}

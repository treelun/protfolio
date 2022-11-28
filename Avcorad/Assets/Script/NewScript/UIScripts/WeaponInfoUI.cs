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
            WeaponName.text = "���� �̸� : " + GameManager.Instance.mainPlayer.playerData.curWeapon.itemName;
            WeaponAttackForce.text = "���� ���ݷ� : " + GameManager.Instance.mainPlayer.playerData.curWeapon.WeaponAttackForce;
            WeaponAttackSpeed.text = "���� ���ݼӵ� : " + GameManager.Instance.mainPlayer.playerData.curWeapon.WeaponAttackSpeed;
        }
        else
        {
            WeaponName.text = "���� �̸� : ";
            WeaponAttackForce.text = "���� ���ݷ� : ";
            WeaponAttackSpeed.text = "���� ���ݼӵ� : ";
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : LivingEntity
{
    //curWeapon : Weapon
    int health;
    int agi;
    int str;

    public void UpdatePlayerData()
    {
        //���⸦ �԰ų� ������ �ø���
    }
    public override void Hit(float _Damaged)
    {
        //�ĸ��� ����??
        base.Hit(_Damaged);
    }
    public void dodge()
    {
        //������
    }
}

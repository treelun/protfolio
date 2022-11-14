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
        //무기를 먹거나 스탯을 올릴때
    }
    public override void Hit(float _Damaged)
    {
        //쳐맞음 무적??
        base.Hit(_Damaged);
    }
    public void dodge()
    {
        //구르기
    }
}

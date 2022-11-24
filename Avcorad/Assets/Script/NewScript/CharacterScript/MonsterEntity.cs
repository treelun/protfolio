using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEntity : LivingEntity
{
    float Damage;
    public float curHp;

    protected GameObject dropObject;

    void Init()
    {

    }
    protected override void OnEnable()
    {
        base.OnEnable();
        Hp = curHp;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEntity : LivingEntity
{
    [Header("Status")]
    [SerializeField] private float _Damage;
    [SerializeField] private float _Hp;
    [SerializeField] private float _AttackSpeed;

    protected GameObject dropObject;

    public Transform target;
    public override void Init()
    {
        base.Init();
        AttackForce = _Damage;
        AttackSpeed = _AttackSpeed;
        Hp = _Hp;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        Init();
        Mystate = State.Move;
    }
}

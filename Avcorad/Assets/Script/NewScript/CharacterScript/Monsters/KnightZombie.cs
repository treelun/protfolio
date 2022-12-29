using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightZombie : MonsterEntity
{
    [Header("Status")]
    [SerializeField] private float _Damage;
    [SerializeField] private float _Hp;
    [SerializeField] private float _AttackSpeed;
    [SerializeField] private float _Exp;


    public override void Init()
    {
        base.Init();
        AttackForce = _Damage;
        AttackSpeed = _AttackSpeed;
        Hp = _Hp;
        EnemyExp = _Exp;
    }
    public override void OnEnable()
    {
        base.OnEnable();
        Init();
        enemyState = EnemyState.Move;
    }
}

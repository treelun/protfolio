using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, ILivingEntity
{
    protected Animator animator;
    protected Rigidbody rigid;
    public float Hp { get; set; }
    public float Sta { get; set; }
    public float moveSpeed { get; set; }
    public float str { get; set; }

    public float agi { get; set; }

    public float Health { get; set; }

    public float rotateSpeed { get; set; }
    public float AttackForce { get; set; }

    public bool isDead { get; set; }
    public bool isDodge { get; set; }



    private void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    public virtual void Attack()
    {
        //공격하는 함수 virtual을 사용하여 상속받는 클래스에서 재정의
    }

    public void Dead()
    {
        if (Hp < float.Epsilon)
        {
            Debug.Log("캐릭터 사망");
            isDead = true;
            
        }
    }

    public virtual void Hit(float _AttackForce)
    {
        
    }

    public void Init(float _Hp, float _Sta, float _Speed, float _rotateSpeed)
    {
        Hp = _Hp;
        Sta = _Sta;
        moveSpeed = _Speed;
        rotateSpeed = _rotateSpeed;
    }

    public virtual void Move()
    {
        //움직임 함수
    }

    //캐릭터가 생성(활성화)될때 가지고 있을 값
    protected virtual void OnEnable()
    {
        isDead = false;
    }

}

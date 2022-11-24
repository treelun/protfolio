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
        //�����ϴ� �Լ� virtual�� ����Ͽ� ��ӹ޴� Ŭ�������� ������
    }

    public void Dead()
    {
        if (Hp < float.Epsilon)
        {
            Debug.Log("ĳ���� ���");
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
        //������ �Լ�
    }

    //ĳ���Ͱ� ����(Ȱ��ȭ)�ɶ� ������ ���� ��
    protected virtual void OnEnable()
    {
        isDead = false;
    }

}

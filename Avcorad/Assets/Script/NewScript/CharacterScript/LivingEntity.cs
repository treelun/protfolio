using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, ILivingEntity
{
    public enum State { Move = 0, Attack, Dodge, Death, Interaction, UseUi,
        Tracking}
    public State Mystate;

    public Animator animator;
    protected Rigidbody rigid;
    public float Hp { get; set; }
    public float Sta { get; set; }

    public float Mp { get; set; }
    public float moveSpeed { get; set; }
    public float str { get; set; }

    public float agi { get; set; }

    public float Health { get; set; }

    public float rotateSpeed { get; set; }
    public float AttackForce { get; set; }

    public float AttackSpeed { get; set; }

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

    public void Death()
    {
        if (Hp <= float.Epsilon)
        {
            Debug.Log("ĳ���� ���");
            isDead = true;
            animator.SetTrigger("Death");
            StartCoroutine(Deathcharator());
            Mystate = State.Death;
        }
    }

    public virtual void Hit(float _AttackForce)
    {
        Hp -= _AttackForce;
        if (Hp > 0)
        {
            animator.SetTrigger("hit");
        }
    }

    public virtual void Init()
    {
        //�θ� Init();
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

    IEnumerator Deathcharator()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }

}

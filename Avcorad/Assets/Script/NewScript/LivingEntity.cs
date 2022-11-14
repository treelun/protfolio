using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, ILivingEntity
{
    public float Hp { get; set; }
    public float Sta { get; set; }
    public float speed { get; set; }

    public void Attack(ILivingEntity _livingEntity)
    {
        //�����ϴ� �Լ�
    }

    public void Die()
    {
        if (Hp < float.Epsilon)
        {
            Debug.Log("ĳ���� ���");
        }
    }

    public virtual void Hit(float _Damaged)
    {
        Hp -= _Damaged;
    }

    public void Init()
    {
        //���� ����
    }

    public void Move()
    {
        //������ �Լ�
    }

}

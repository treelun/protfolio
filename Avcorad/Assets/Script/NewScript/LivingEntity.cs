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
        //공격하는 함수
    }

    public void Die()
    {
        if (Hp < float.Epsilon)
        {
            Debug.Log("캐릭터 사망");
        }
    }

    public virtual void Hit(float _Damaged)
    {
        Hp -= _Damaged;
    }

    public void Init()
    {
        //변수 설정
    }

    public void Move()
    {
        //움직임 함수
    }

}

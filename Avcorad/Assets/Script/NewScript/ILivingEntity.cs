using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILivingEntity
{
    float Hp { get; set; }
    float Sta { get; set; }
    float speed { get; set; }

    //�´� �Լ�
    void Hit(float _Damaged);

    //�����ϴ� �Լ�
    void Attack(ILivingEntity _livingEntity);

    //�״� �Լ�
    void Die();
    //�����̴� �Լ�
    void Move();
    //data�� ������ �Լ�
    void Init();
}

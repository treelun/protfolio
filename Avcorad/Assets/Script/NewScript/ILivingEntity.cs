using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILivingEntity
{
    float Hp { get; set; }
    float Sta { get; set; }
    float speed { get; set; }

    //맞는 함수
    void Hit(float _Damaged);

    //공격하는 함수
    void Attack(ILivingEntity _livingEntity);

    //죽는 함수
    void Die();
    //움직이는 함수
    void Move();
    //data를 변경할 함수
    void Init();
}

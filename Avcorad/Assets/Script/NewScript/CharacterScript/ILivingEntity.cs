
public interface ILivingEntity
{
    float Hp { get; set; }
    float Sta { get; set; }
    float moveSpeed { get; set; }

    float str { get; set; }

    float agi { get; set; }
    float Health { get; set; }

    float AttackForce { get; set; }

    float AttackSpeed { get; set; }


    //맞는 함수
    void Hit(float _Damaged);

    //공격하는 함수
    void Attack();

    //죽는 함수
    void Death();
    //움직이는 함수
    void Move();
    //data를 변경할 함수
    void Init(float _Hp, float _Sta, float _Speed, float _rotateSpeed, float _AttackForce, float _AttackSpeed);
}

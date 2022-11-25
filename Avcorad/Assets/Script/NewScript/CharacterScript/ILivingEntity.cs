
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


    //�´� �Լ�
    void Hit(float _Damaged);

    //�����ϴ� �Լ�
    void Attack();

    //�״� �Լ�
    void Death();
    //�����̴� �Լ�
    void Move();
    //data�� ������ �Լ�
    void Init(float _Hp, float _Sta, float _Speed, float _rotateSpeed, float _AttackForce, float _AttackSpeed);
}

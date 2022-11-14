
public interface ILivingEntity
{
    float Hp { get; set; }
    float Sta { get; set; }
    float moveSpeed { get; set; }


    //�´� �Լ�
    void Hit(float _Damaged);

    //�����ϴ� �Լ�
    void Attack();

    //�״� �Լ�
    void Dead();
    //�����̴� �Լ�
    void Move();
    //data�� ������ �Լ�
    void Init(float _Hp, float _Sta, float _Speed, float _rotateSpeed);
}

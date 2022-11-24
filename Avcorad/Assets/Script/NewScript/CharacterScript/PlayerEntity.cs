using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEntity : LivingEntity
{
    public enum State { Move = 0, Attack,  Dodge, Dead, Interaction }
    public State Mystate;


    public Weapon curWeapon;
    public Weapon newWeapon;
    Vector3 movement;


    //ĳ������ ������ �����Ϳ��� �����ϱ����� public ����

    public float maxHp;
    float curHp;
    public float maxSta;
    float curSta;
    public float playerAttackForce;
    public float playerMoveSpeed;
    public float roSpeed;
    public float jumpForce;
    public float currentExp;
    public float requiredExp;
    public int levelupPoint;
    float attackSpeed;

    //�÷��̾��� ���� ����
    bool isLevelup;
    bool isJump;

    public void UpdatePlayerData()
    {
        //���⸦ �԰ų� ������ �ø���
        if (isLevelup)
        {
            levelupPoint = 5;
            requiredExp *= 1.5f;
            isLevelup = false;
        }
    }
    public override void Attack()
    {
        base.Attack();

        animator.SetTrigger("ComboAttack");
        animator.SetFloat("SetAttackSpeed", attackSpeed / 2);
    }
    public override void Hit(float _AttackForce)
    {
        //�ĸ���
        base.Hit(_AttackForce);
        curHp -= _AttackForce;
        
        animator.SetTrigger("hit");
    }
    public void dodge()
    {
        animator.SetTrigger("dodge");
    }
    public void Jump()
    {
        if (!isJump)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJump = true;
            animator.SetTrigger("JumpTrigger");

            //player.startingStamina -= attackStamina + 10f;
        }
    }

    public override void Move()
    {
       
        //������ �Լ�
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        movement = new Vector3(deltaX, 0f, deltaZ).normalized;
        
        movement = transform.TransformDirection(movement);

        transform.Rotate(0f, Input.GetAxis("Mouse X") * roSpeed, 0f, Space.World);
        transform.position += movement * moveSpeed * Time.deltaTime;
       
        //���⿡���� �̵� �ִϸ��̼� ���������
        if (deltaX != 0)
        {
            animator.SetFloat("Horizontal", deltaX);
        }
        if (deltaZ != 0)
        {
            animator.SetFloat("Vertical", deltaZ);
        }
    }

    //ĳ���Ͱ� Ȱ��ȭ �ɶ� ������ ��������
    protected override void OnEnable()
    {
        base.OnEnable();
        curHp = maxHp;
        curSta = maxSta;
        requiredExp = 100;
        playerAttackForce = curWeapon.AttackForce;
        Init(curHp, curSta, playerMoveSpeed, roSpeed);
        attackSpeed = curWeapon.AttackSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Debug.Log("�÷��̾� ������ ����");
            isJump = false;
        }
    }

    public void playerLevelup()
    {
        if (currentExp >= requiredExp)
        {
            isLevelup = true;
            UpdatePlayerData();
            currentExp = 0;
        }
    }
    public void GetWeapon(Weapon _weapon)
    {
        newWeapon = _weapon;
    }
    public void SetWeapon()
    {
        //������ Weapon�� �ٲ���
        curWeapon = newWeapon;
        Debug.Log(curWeapon);
    }


    public void AttackStart()
    {
        //Mystate = State.Attack;
        //���ݽ��۽� ����Ʈ�� �ݶ��̴�Ȱ��ȭ
    }
    public void StateEnd()
    {
        Mystate = State.Move;
    }

    public void DodgeStart()
    {
        //Mystate = State.Dodge;
        gameObject.layer = 7;
    }
    public void DodgeEnd()
    {
        Mystate = State.Move;
        gameObject.layer = 6;
    }
}

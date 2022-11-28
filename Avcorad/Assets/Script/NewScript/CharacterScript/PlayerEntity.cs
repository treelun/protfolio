using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : LivingEntity
{
    public Weapon curWeapon { get; set; }
    Vector3 movement;


    //ĳ������ ������ �����Ϳ��� �����ϱ����� public ����

    public float maxHp;
    float curHp;
    public float maxSta;
    float curSta;

    public float playerAttackForce;
    public float playerAttackSpeed;
    public float playerMoveSpeed;
    
    public float _rotateSpeed;
    public float jumpForce;
    public float currentExp;
    public float requiredExp;
    public int playerLevel;
    public int levelupPoint;

    public string itemName;
    //�÷��̾��� ���� ����
    public bool isJump;
    
    public void LevelUp()
    {
        levelupPoint = 5;
    }
    
    public void SetEquipAttackEntity(Weapon _curWeapon) {
        //���� �̸� �ٲٱ�
        //���� ���ݷ� �ٲٱ�
        //���� ���ݼӵ� �ٲٱ�
        itemName = _curWeapon.itemName;
        playerAttackForce += _curWeapon.WeaponAttackForce;
        playerAttackSpeed += _curWeapon.WeaponAttackSpeed;
    }
    public void SetNotEquipAttackEntity(ItemInfo _curWeapon)
    {
        itemName = "";
        playerAttackForce -= _curWeapon.item.AttackForce;
        playerAttackSpeed -= _curWeapon.item.AttackSpeed;
    }

    public void InitPlayerStat(string _BtnName)
    {
        //��ư�� �̸��� ���� ������ ����Ʈ�� 0���� ũ��
        if (_BtnName == "StrBtn" && levelupPoint > 0)
        {
            levelupPoint--;
            str++;
            playerAttackForce += 1f;
        }
        else if (_BtnName == "AgiBtn" && levelupPoint > 0)
        {
            levelupPoint--;
            agi++;
            playerMoveSpeed += 0.1f;
            playerAttackSpeed += 0.02f;
        }
        else if (_BtnName == "HealthBtn" && levelupPoint > 0)
        {
            levelupPoint--;
            Health++;
            maxHp += 10f;
            maxSta += 5f;
        }
    }

    public void UpdatePlayerData()
    {
        //���⸦ �԰ų� ������ �ø���
    }
    public override void Attack()
    {
        base.Attack();

        animator.SetTrigger("ComboAttack");
        animator.SetFloat("SetAttackSpeed", playerAttackSpeed);
        Mystate = State.Attack;
    }
    public override void Hit(float _AttackForce)
    {
        //�ĸ���
        base.Hit(_AttackForce);
        //�¾������� �ǰ� ����Ʈ(�ִϸ��̼��̳� ��¦��)
        
    }
    public void dodge()
    {
        animator.SetTrigger("dodge");
        animator.SetFloat("MoveSpeed", playerMoveSpeed / 6);
        Sta -= 10f;
    }
    public void Jump()
    {
        if (!isJump)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("JumpTrigger");

            Sta -= 30f;
            isJump = true;
        }
    }

    public override void Move()
    {
       
        //������ �Լ�
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        movement = new Vector3(deltaX, 0f, deltaZ).normalized;
        
        movement = transform.TransformDirection(movement);

        transform.Rotate(0f, Input.GetAxis("Mouse X") * _rotateSpeed, 0f, Space.World);
        transform.position += movement * moveSpeed * Time.deltaTime;

        animator.SetFloat("MoveSpeed", playerMoveSpeed / 6);
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
        //�ִ�ü��,�ִ뽺�¹̳ʸ� ����ü�°� ���¹̳ʷ� ����
        //LivingEntity�� HP�� Sta���� ���� HP,Sta������ ����
        //�ӵ� ����
        Init(maxHp, maxSta, playerMoveSpeed, _rotateSpeed, playerAttackForce, playerAttackSpeed);
        //�ʿ����ġ ����
        requiredExp = 100;
        playerLevel = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isJump = false;
        }
    }

    public void playerLevelup()
    {
        if (currentExp >= requiredExp)
        {
            currentExp = 0;
            levelupPoint += 5;
            requiredExp *= 1.5f;
            playerLevel++;
        }
    }

    public void AttackStart()
    {
        Mystate = State.Attack;
        //���ݽ��۽� ����Ʈ�� �ݶ��̴�Ȱ��ȭ
        Sta -= 20f;
    }
    public void StateEnd()
    {
        
        if (Mystate == State.UseUi)
        {
            Mystate = State.UseUi;
        }
        else
        {
            Mystate = State.Move;
        }
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

    public void RegenSta()
    {
        if (Sta < maxSta)
        {
            Sta += maxSta * 0.002f;
        }
    }
}

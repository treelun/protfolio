using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : LivingEntity
{
    public Weapon curWeapon { get; set; }
    Vector3 movement;


    //캐릭터의 정보들 에디터에서 관리하기위해 public 선언

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
    //플레이어의 상태 변수
    public bool isJump;
    
    public void LevelUp()
    {
        levelupPoint = 5;
    }
    
    public void SetEquipAttackEntity(Weapon _curWeapon) {
        //무기 이름 바꾸기
        //무기 공격력 바꾸기
        //무기 공격속도 바꾸기
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
        //버튼의 이름이 같고 레벨업 포인트가 0보다 크면
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
        //무기를 먹거나 스탯을 올릴때
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
        //쳐맞음
        base.Hit(_AttackForce);
        //맞았을때의 피격 이펙트(애니메이션이나 반짝임)
        
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
       
        //움직임 함수
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        movement = new Vector3(deltaX, 0f, deltaZ).normalized;
        
        movement = transform.TransformDirection(movement);

        transform.Rotate(0f, Input.GetAxis("Mouse X") * _rotateSpeed, 0f, Space.World);
        transform.position += movement * moveSpeed * Time.deltaTime;

        animator.SetFloat("MoveSpeed", playerMoveSpeed / 6);
        //방향에따른 이동 애니메이션 재생을위해
        if (deltaX != 0)
        {
            animator.SetFloat("Horizontal", deltaX);
        }
        if (deltaZ != 0)
        {
            animator.SetFloat("Vertical", deltaZ);
        }
    }

    //캐릭터가 활성화 될때 값들을 설정해줌
    protected override void OnEnable()
    {
        base.OnEnable();
        //최대체력,최대스태미너를 현재체력과 스태미너로 설정
        //LivingEntity의 HP와 Sta값을 현재 HP,Sta값으로 설정
        //속도 설정
        Init(maxHp, maxSta, playerMoveSpeed, _rotateSpeed, playerAttackForce, playerAttackSpeed);
        //필요경험치 설정
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
        //공격시작시 이펙트와 콜라이더활성화
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

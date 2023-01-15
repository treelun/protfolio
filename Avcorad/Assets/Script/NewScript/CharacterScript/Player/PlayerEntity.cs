using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using UnityEngine.UI;

public class PlayerEntity : LivingEntity
{
    public enum State
    {
        Move = 0, Attack, Dodge, Death, Interaction, UseUi,
        Tracking, Hit
    }
    public State Mystate;

    public Weapon curWeapon { get; set; }
    public GameObject WeaponSlot;
    Vector3 movement;


    //캐릭터의 정보들 에디터에서 관리하기위해 public 선언
    [Header("PlayerStatus")]
    public float maxHp; 
    public float maxSta;
    public float maxMp;
    public float agi;
    public float str;
    public float Health;
    [Space]
    [SerializeField]
    public float playerAttackForce, playerAttackSpeed, playerMoveSpeed, _rotateSpeed, jumpForce,
        currentExp, requiredExp;
    [Space]
    [HideInInspector]
    public int playerLevel, levelupPoint;
    [HideInInspector]
    public string itemName;
    //플레이어의 상태 변수
    [HideInInspector]
    public bool isJump;


    [Header("Feedbacks")]
    [SerializeField]
    /// a feedback to be played when the jump happens
    private MMFeedbacks JumpFeedbacks;
    [SerializeField]
    /// a feedback to be played when the cube lands
    private MMFeedbacks LandingFeedbacks;

    public AudioSource audioSource;

    public AudioClip dodgeSound;
    public AudioClip attackSound;

    public Image bloodScreen;

    public void LevelUp()
    {
        levelupPoint = 5;
    }

    public override void Init()
    {
        base.Init();
        Hp = maxHp;
        Sta = maxSta;
        Mp = maxMp;
        moveSpeed = playerMoveSpeed;
        rotateSpeed = _rotateSpeed;
        AttackForce = playerAttackForce;
        AttackSpeed = playerAttackSpeed;
    }



    public void SetEquipAttackEntity(Weapon _curWeapon) {
        //무기 이름 바꾸기
        //무기 공격력 바꾸기
        //무기 공격속도 바꾸기
        itemName = _curWeapon.itemName;
        playerAttackForce += _curWeapon.WeaponAttackForce;
        playerAttackSpeed += _curWeapon.WeaponAttackSpeed;
    }
    public void SetNotEquipAttackEntity(Weapon _curWeapon)
    {
        itemName = "";
        playerAttackForce -= _curWeapon.WeaponAttackForce;
        playerAttackSpeed -= _curWeapon.WeaponAttackSpeed;
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
            Hp = maxHp;
            Sta = maxSta;
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
        StartCoroutine(HitEffectOnOff());
        if (Mystate != PlayerEntity.State.Attack)
        {
            animator.SetTrigger("hit");
        }
        if (Hp <= float.Epsilon)
        {
            Mystate = PlayerEntity.State.Death;
            Death();
            tag = "EnemyDeath";
        }

    }
    public void dodge()
    {
        animator.SetTrigger("dodge");
        animator.SetFloat("MoveSpeed", playerMoveSpeed / 6);
        Sta -= 10f;
        audioSource.clip = dodgeSound;
        audioSource.Play();
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

        
        transform.position += movement * moveSpeed * Time.deltaTime;

        animator.SetFloat("MoveSpeed", playerMoveSpeed / 6);

        transform.Rotate(0f, Input.GetAxis("Mouse X") * _rotateSpeed, 0f, Space.World);
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
    public override void OnEnable()
    {
        base.OnEnable();
        //최대체력,최대스태미너를 현재체력과 스태미너로 설정
        //LivingEntity의 HP와 Sta값을 현재 HP,Sta값으로 설정
        //속도 설정
        Init();
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
            requiredExp *= 1.2f;
            playerLevel++;
        }
    }

    public void AttackStart()
    {
        Mystate = State.Attack;
        //공격시작시 이펙트와 콜라이더활성화
        audioSource.clip = attackSound;
        audioSource.Play();
        Sta -= 5f;
        
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
    public void AttackCollider()
    {
        curWeapon.capsulecollider.enabled = true;
        curWeapon.trailRenderer.enabled = true;
    }
    public void EndCollider()
    {
        curWeapon.capsulecollider.enabled = false;
        curWeapon.trailRenderer.enabled = false;
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

    public void JumpAttackStart()
    {
        JumpFeedbacks?.PlayFeedbacks();
    }
    public void JumpAttackEnd()
    {
        LandingFeedbacks?.PlayFeedbacks();
    }
    public void HitEnd()
    {
        Mystate = State.Move;
    }

    IEnumerator HitEffectOnOff()
    {
        bloodScreen.color = new Color(1, 0, 0, Random.Range(0.2f, 0.3f));
        yield return new WaitForSeconds(0.1f);
        bloodScreen.color = Color.clear;
    }
}

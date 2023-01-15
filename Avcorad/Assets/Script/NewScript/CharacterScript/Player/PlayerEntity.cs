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


    //ĳ������ ������ �����Ϳ��� �����ϱ����� public ����
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
    //�÷��̾��� ���� ����
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
        //���� �̸� �ٲٱ�
        //���� ���ݷ� �ٲٱ�
        //���� ���ݼӵ� �ٲٱ�
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
            Hp = maxHp;
            Sta = maxSta;
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
        //������ �Լ�
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        movement = new Vector3(deltaX, 0f, deltaZ).normalized;

        movement = transform.TransformDirection(movement);

        
        transform.position += movement * moveSpeed * Time.deltaTime;

        animator.SetFloat("MoveSpeed", playerMoveSpeed / 6);

        transform.Rotate(0f, Input.GetAxis("Mouse X") * _rotateSpeed, 0f, Space.World);
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
    public override void OnEnable()
    {
        base.OnEnable();
        //�ִ�ü��,�ִ뽺�¹̳ʸ� ����ü�°� ���¹̳ʷ� ����
        //LivingEntity�� HP�� Sta���� ���� HP,Sta������ ����
        //�ӵ� ����
        Init();
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
            requiredExp *= 1.2f;
            playerLevel++;
        }
    }

    public void AttackStart()
    {
        Mystate = State.Attack;
        //���ݽ��۽� ����Ʈ�� �ݶ��̴�Ȱ��ȭ
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

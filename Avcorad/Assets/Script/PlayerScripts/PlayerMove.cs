using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Status
{
    public float moveSpeed = 8f;
    public float rotateSpeed = 5f;
    public float jumpPower = 10f;
    Rigidbody rigid;
    Animator animator;
    Weapon Weapon;
    public WeaponData weaponData;

    public CharaterData player;

    public AudioSource RightWalkAudio;
    public AudioSource LeftWalkAudio;
    public AudioSource dodge;

    public ParticleSystem particle;

    Vector3 movement;

    float deltaX;
    float deltaZ;
    float AttackDelay;
    public float Hitpoint;
    float attackCount;
    float attackTimeReset;
    public float attackStamina;

    bool JumpButton;
    bool AttackButton;

    bool isJump;
    bool isDodge;
    bool isAttackReady = true;
    public bool ishit;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        Weapon = GetComponentInChildren<Weapon>();
    }

    private void FixedUpdate()
    {
        GetInput();
        playerMove();
        Jump();
        Dodge();
        Attack();
        Recovery();
    }
    void GetInput()
    {
        JumpButton = Input.GetButtonDown("Jump");
        deltaX = Input.GetAxis("Horizontal");
        deltaZ = Input.GetAxis("Vertical");
        AttackButton = Input.GetMouseButtonDown(0);

    }

    void playerMove()
    {
        if (!isAttackReady || isDodge || ishit)
        {
            movement = Vector3.zero;
        }

        movement = new Vector3(deltaX, 0f, deltaZ);

        movement = transform.TransformDirection(movement);

        transform.Rotate(0f, Input.GetAxis("Mouse X") * rotateSpeed, 0f, Space.World);
        if (deltaX != 0)
        {
            animator.SetFloat("Vertical", deltaX);
           
        }
        if (deltaZ != 0)
        {
            animator.SetFloat("Horizontal", deltaZ);
        }

        
        transform.position += movement * moveSpeed * Time.deltaTime;
  
    }
    void Jump()
    {
        if (JumpButton && !isJump && player.startingStamina > 20)
        {
            Debug.Log("점프");
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
            animator.SetTrigger("JumpTrigger");
            player.startingStamina -= attackStamina + 10f;
        }
    }
    void Dodge()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isJump && !isDodge && player.startingStamina > 20)
        {
            animator.SetTrigger("dodgeleft");
            dodge.Play();
            StartCoroutine(playerDodge());
            player.startingStamina -= attackStamina + 10f;
        }
    }


    public void Attack()
    {
        AttackDelay += Time.deltaTime;

        isAttackReady = weaponData.attackSpeed < AttackDelay;

        attackTimeReset += Time.deltaTime;
        if (AttackButton && isAttackReady && !ishit && player.startingStamina > 5)
        {
            animator.SetTrigger("AttackTrigger");

            animator.SetFloat("AttackFloat", attackCount);
            
            particle.GetComponent<ParticleSystem>().Play();
    

            player.startingStamina -= attackStamina;
            attackCount++;

            //실질적인 공격실행 메서드
            Weapon.PlayerMeleeAttack();
            AttackDelay = 0;
            attackTimeReset = 0;

           
            if (attackCount > 2)
            {
                attackCount = 0;
            }

        }
        //일정시간동안 공격하지않으면 공격모션을 첫번째로 돌려줌
        if (attackTimeReset > 2 && isAttackReady)
        {
            attackCount = 0;
            attackTimeReset = 0;
        }

    }
   
    void KillCharacter()
    {
        Destroy(gameObject);
    }
    public void ResetCharacter()
    {
        player.startingHp = startHp;
        player.startingStamina = startSta;
    }
    private void OnEnable()
    {
        ResetCharacter();
    }

    public void DamageCharacter(float damage)
    {
        player.startingHp -= damage;
        animator.SetTrigger("hitMotion");
        StartCoroutine(playerHit());
        if (player.startingHp <= float.Epsilon) //float.Epsilon은 0보다 큰 가장 작은 양수의 값을 나타냄
        {
            KillCharacter();
        }
    }
    IEnumerator playerHit()
    {
        ishit = true;
        gameObject.layer = 7;
        yield return new WaitForSeconds(0.8f);
        gameObject.layer = 6;
        ishit = false;
        
    }

    IEnumerator playerDodge()
    {
        gameObject.layer = 7;
        isDodge = true;
        yield return new WaitForSeconds(0.8f);
        gameObject.layer = 6;
        isDodge = false;
    }
    void Recovery()
    {
        StartCoroutine(Recover());
    }

    IEnumerator Recover()
    {

        if (player.startingStamina < maxSta)
        {
            player.startingStamina += 15f * Time.deltaTime;
        }
        yield return new WaitForSeconds(10f);

        if (player.startingHp < maxHp)
        {
            player.startingHp += 0.1f * Time.deltaTime;
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isJump = false;
        }
    }

}

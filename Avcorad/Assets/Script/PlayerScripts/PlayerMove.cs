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
        playerMove();

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



    public void ResetCharacter()
    {
        player.startingHp = startHp;
        player.startingStamina = startSta;
    }
    private void OnEnable()
    {
        ResetCharacter();
    }



}

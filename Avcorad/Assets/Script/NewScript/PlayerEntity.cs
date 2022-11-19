using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : LivingEntity
{
    
    public GameObject curWeapon;
    public TrailRenderer trailRenderer;


    //캐릭터의 정보들 에디터에서 관리하기위해 public 선언
    int currenthealth;
    int currentagi;
    int currentstr;
    public float maxHp;
    float curHp;
    public float maxSta;
    float curSta;
    public float playerMoveSpeed;
    public float roSpeed;
    public float jumpForce;
    int levelupPoint;
    float attackSpeed;

    //플레이어의 상태 변수
    bool isLevelup;
    bool isJump;
    bool isAttack;
    bool isGetItem;
    public void UpdatePlayerData()
    {
        //무기를 먹거나 스탯을 올릴때
        if (isLevelup)
        {
            levelupPoint = 5;
            maxHp += 10;
            maxSta += 20;
            playerMoveSpeed += 5;
            
            
            OnEnable();
            Debug.Log("현재 체력" + curHp);
            Debug.Log("현재 스태미너" + curSta);
            isLevelup = false;
        }
    }
    public override void Attack()
    {
        base.Attack();
        
        if (Input.GetMouseButtonDown(0) && !isDodge && !isJump)
        {
            animator.SetTrigger("ComboAttack");
            animator.SetFloat("SetAttackSpeed", attackSpeed/2);
        }
    }
    public override void Hit(float _AttackForce)
    {
        //쳐맞음
        base.Hit(_AttackForce);
        curHp -= _AttackForce;
        
        animator.SetTrigger("hit");
    }
    public void dodge()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDodge && !isDead && !isJump)
        {
            animator.SetTrigger("dodge");
        }
    }
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJump && !isDodge && !isDead)
        {
            
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJump = true;
            animator.SetTrigger("JumpTrigger");
            //player.startingStamina -= attackStamina + 10f;
        }
    }
    public override void Move()
    {
        Debug.Log(attackSpeed);
        Debug.Log("isAttack : " + isAttack);
        //움직임 함수
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(deltaX, 0f, deltaZ).normalized;
        //state = State.Move;
        if (isDodge || isAttack)
        {
            movement = Vector3.zero;
        }
        
        movement = transform.TransformDirection(movement);

        transform.Rotate(0f, Input.GetAxis("Mouse X") * roSpeed, 0f, Space.World);
        transform.position += movement * moveSpeed * Time.deltaTime;
       
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
        curHp = maxHp;
        curSta = maxSta;
        Init(curHp, curSta, playerMoveSpeed, roSpeed);

        attackSpeed = curWeapon.GetComponent<Weapon>().AttackSpeed;


    }

    //회피시 무적시간 설정
    IEnumerator SetDodge()
    {
        isDodge = true;
        gameObject.layer = 7;
        Debug.Log("코루틴 실행... isDodge : " + isDodge);
        yield return new WaitForSeconds(1f);
        isDodge = false;
        Debug.Log("코루틴 실행중... isDodge : " + isDodge);
        yield return new WaitForSeconds(1f);
        gameObject.layer = 6;
        Debug.Log("코루틴 실행중...플레이어 레이어 변경");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Debug.Log("플레이어 땅위에 있음");
            isJump = false;
        }
    }

    public void btnLevelup()
    {
        isLevelup = true;
    }

    public void AttackStart()
    {
        isAttack = true;
        curWeapon.GetComponent<Weapon>().swingparticle.Play();
        trailRenderer.enabled = true;
    }
    public void AttackEnd()
    {
        isAttack = false;
        trailRenderer.enabled = false;
    }

    public void DodgeStart()
    {
        isDodge = true;
        gameObject.layer = 7;
    }
    public void DodgeEnd()
    {
        isDodge = false;
        gameObject.layer = 6;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : LivingEntity
{
    
    public GameObject curWeapon;
    public TrailRenderer trailRenderer;


    //ĳ������ ������ �����Ϳ��� �����ϱ����� public ����
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

    //�÷��̾��� ���� ����
    bool isLevelup;
    bool isJump;
    bool isAttack;
    bool isGetItem;
    public void UpdatePlayerData()
    {
        //���⸦ �԰ų� ������ �ø���
        if (isLevelup)
        {
            levelupPoint = 5;
            maxHp += 10;
            maxSta += 20;
            playerMoveSpeed += 5;
            
            
            OnEnable();
            Debug.Log("���� ü��" + curHp);
            Debug.Log("���� ���¹̳�" + curSta);
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
        //�ĸ���
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
        //������ �Լ�
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
        Init(curHp, curSta, playerMoveSpeed, roSpeed);

        attackSpeed = curWeapon.GetComponent<Weapon>().AttackSpeed;


    }

    //ȸ�ǽ� �����ð� ����
    IEnumerator SetDodge()
    {
        isDodge = true;
        gameObject.layer = 7;
        Debug.Log("�ڷ�ƾ ����... isDodge : " + isDodge);
        yield return new WaitForSeconds(1f);
        isDodge = false;
        Debug.Log("�ڷ�ƾ ������... isDodge : " + isDodge);
        yield return new WaitForSeconds(1f);
        gameObject.layer = 6;
        Debug.Log("�ڷ�ƾ ������...�÷��̾� ���̾� ����");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Debug.Log("�÷��̾� ������ ����");
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

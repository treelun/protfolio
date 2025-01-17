using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class LivingEntity : MonoBehaviour, ILivingEntity
{
    public Animator animator;
    protected Rigidbody rigid;
    public float Hp { get; set; }
    public float Sta { get; set; }

    public float Mp { get; set; }
    public float moveSpeed { get; set; }
/*    public float str { get; set; }

    public float agi { get; set; }

    public float Health { get; set; }
*/
    public float rotateSpeed { get; set; }
    public float AttackForce { get; set; }

    public float AttackSpeed { get; set; }

    public float EnemyExp { get; set; }

    public bool isDead { get; set; }
    public bool isDodge { get; set; }

    [SerializeField]
    /// a feedback to be played when the cube lands
    private MMFeedbacks Flicker;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    public virtual void Attack()
    {
        //공격하는 함수 virtual을 사용하여 상속받는 클래스에서 재정의
    }

    public virtual void Death()
    {
       
        Debug.Log("캐릭터 사망");
        isDead = true;
        animator.SetTrigger("Death");
        StartCoroutine(Deathcharator());
        
    }

    public virtual void Hit(float _AttackForce)
    {
        Hp -= _AttackForce;
        Flicker?.PlayFeedbacks();
    }

    public virtual void Init()
    {
        //부모가 Init();
    }

    public virtual void Move()
    {
        //움직임 함수
    }

    //캐릭터가 생성(활성화)될때 가지고 있을 값
    public virtual void OnEnable()
    {
        isDead = false;
    }

    IEnumerator Deathcharator()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }
}

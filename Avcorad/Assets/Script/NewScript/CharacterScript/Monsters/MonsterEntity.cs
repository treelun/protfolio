using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class MonsterEntity : MonoBehaviour, ILivingEntity
{
    public enum EnemyState
    {
        Move = 0, Attack, Death, Tracking
    }
    EnemyState _enemyState;

    public EnemyState enemyState
    {
        get { return _enemyState; }
        set
        {
            switch (value)
            {
                case EnemyState.Attack:
                    StopCoroutine(EnemyWalk());
                    StopCoroutine(StartTraking());
                    Attack();
                    break;
                case EnemyState.Move:

                    Debug.Log("EnemyState : Move");
                    StartCoroutine(EnemyWalk());
                    //Move();
                    break;
                case EnemyState.Death:
                    DropItemAndExp();
                    StopCoroutine(EnemyWalk());
                    StopCoroutine(StartTraking());
                    Death();
                    target = null;
                    gameObject.layer = 18;
                    playerCheckCollier.gameObject.layer = 18;
                    AttackBox.gameObject.layer = 18;
                    break;
                case EnemyState.Tracking:
                    Debug.Log("트래킹 실행");
                    StopCoroutine(EnemyWalk());
                    StartCoroutine(StartTraking());
                    break;
                default:
                    break;
            }
            _enemyState = value;
        }
    }

    public enum EnemyType
    {
        Zombie, Alien
    }
    public EnemyType enemyType;

    protected GameObject dropObject;

    public Animator animator;

    public Transform target;

    public SphereCollider playerCheckCollier;
    public BoxCollider AttackBox;
    [SerializeField]
    /// a feedback to be played when the cube lands
    private MMFeedbacks Flicker;

    public float Hp { get; set ; }
    public float Sta { get ; set ; }
    public float Mp { get ; set ; }
    public float moveSpeed { get ; set ; }
    public float AttackForce { get ; set ; }
    public float AttackSpeed { get ; set ; }
    public float EnemyExp { get; set; }
    public bool isDead { get; set; }

    int turnType;

    private void Start()
    {
        GameManager.Instance.itembox.SetObject(new Vector3(transform.position.x, 1, transform.position.z));
    }

    public virtual void Init()
    {

    }
    public virtual void OnEnable()
    {

    }

    public virtual void Attack()
    {
        if (enemyType == EnemyType.Zombie)
        {
            animator.SetBool("isAttack", true);
            animator.SetBool("isAttack2", true);
        }
        else if (enemyType == EnemyType.Alien)
        {

        }
    }

    //아이템, 경험치 drop(아이템드랍은 인터넷 참조 예상으로는 죽으면 > 비활성화된 아이템 프리펩 true로 바꾸고,
    //먹으면 비활성화, position은 몬스터의 위치로)
    public void DropItemAndExp()
    {
        int random = Random.Range(0, 5);
        GameManager.Instance.mainPlayer.playerData.currentExp += EnemyExp;
        //아이템 드랍
        for (int i = 0; i < random; i++)
        {
            if (random < 3)
            {
                GameManager.Instance.itembox.GetHpPotion(i).transform.position = new Vector3(transform.position.x, 1, transform.position.z);
                GameManager.Instance.itembox.GetHpPotion(i).SetActive(true);
            }
            else if(random >= 3)
            {
                GameManager.Instance.itembox.GetMpPotion(i).transform.position = new Vector3(transform.position.x, 1, transform.position.z);
                GameManager.Instance.itembox.GetMpPotion(i).SetActive(true);
            }
        }

        //오브젝트 풀링으로 아이템 드롭 구현
    }

    public IEnumerator EnemyWalk()
    {
        while (true)
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("isAttack2", false);
            animator.SetBool("isRun", false);
            animator.SetBool("isTurn", false);
            animator.SetBool("isTurn2", false);
            animator.SetBool("isWalk", true);
            yield return new WaitForSeconds(10f);
            turnType = Random.Range(0, 2);
            
            if (turnType == 0)
            {
                animator.SetBool("isWalk", false);
                animator.SetBool("isTurn", true);
            }
            else if (turnType == 1)
            {
                animator.SetBool("isWalk", false);
                animator.SetBool("isTurn2", true);
            }
            yield return new WaitForSeconds(3f);
        }
    }

    //추적
    public IEnumerator StartTraking()
    {
        while (target != null)
        {
            if (enemyState == EnemyState.Tracking)
            {
                animator.SetBool("isAttack", false);
                animator.SetBool("isAttack2", false);
                animator.SetBool("isRun", true);
                transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
            }
            else if (enemyState == EnemyState.Attack)
            {
                animator.SetBool("isRun", false);
            }
            yield return null;
        }

    }


    public void StartAttack()
    {
        AttackBox.enabled = true;
    }
    public void EndAttack()
    {
        AttackBox.enabled = false;
    }

    public void Hit(float _Damaged)
    {
        Hp -= _Damaged;
        Flicker?.PlayFeedbacks();
    }

    public void Death()
    {
        Debug.Log("캐릭터 사망");
        isDead = true;
        animator.SetTrigger("Death");
        StartCoroutine(Deathcharator());
    }

    public virtual void Move()
    {
        
    }

    IEnumerator Deathcharator()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }
}

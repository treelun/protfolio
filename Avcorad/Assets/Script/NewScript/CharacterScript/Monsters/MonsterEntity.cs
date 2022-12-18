using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEntity : LivingEntity
{
    State _state;
    public State state
    {
        get { return _state; }
        set
        {
            switch (value)
            {
                case State.Attack:
                    StopCoroutine(EnemyWalk());
                    StopCoroutine(StartTraking());
                    Attack();
                    break;
                case State.Move:
                    StopCoroutine(StartTraking());
                    //StopCoroutine(AttackType());
                    StartCoroutine(EnemyWalk());
                    break;
                case State.Death:
                    StopCoroutine(EnemyWalk());
                    StopCoroutine(StartTraking());
                    Death();

                    DropItemAndExp();
                    target = null;
                    AttackBox.enabled = false;
                    capsuleCollider.enabled = false;
                    playerCheckCollier.enabled = false;
                    break;
                case State.Tracking:
                    StopCoroutine(EnemyWalk());
                    //StopCoroutine(AttackType());
                    StartCoroutine(StartTraking());
                    break;
                default:
                    break;
            }
            _state = value;
        }
    }


    [Header("Status")]
    [SerializeField] private float _Damage;
    [SerializeField] private float _Hp;
    [SerializeField] private float _AttackSpeed;
    [SerializeField] private float _Exp;

    protected GameObject dropObject;



    public Transform target;

    public CapsuleCollider capsuleCollider;
    public SphereCollider playerCheckCollier;
    public BoxCollider AttackBox;

    public ItemBox itembox;

    int turnType;


    public override void Init()
    {
        base.Init();
        AttackForce = _Damage;
        AttackSpeed = _AttackSpeed;
        Hp = _Hp;
        EnemyExp = _Exp;
        
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        Init();
        
        state = State.Death;
    }

    public override void Attack()
    {
        base.Attack();

        animator.SetBool("isAttack", true);
        animator.SetBool("isAttack2", true);

    }

    //아이템, 경험치 drop(아이템드랍은 인터넷 참조 예상으로는 죽으면 > 비활성화된 아이템 프리펩 true로 바꾸고,
    //먹으면 비활성화, position은 몬스터의 위치로)
    void DropItemAndExp()
    {
        GameManager.Instance.mainPlayer.playerData.currentExp += EnemyExp;
        for (int i = 0; i < itembox.GetListCount(); i++)
        {
            itembox.GetObject(i).transform.position = transform.position;
            itembox.GetObject(i).SetActive(true);
        }

       
        //오브젝트 풀링으로 아이템 드롭 구현
    }

    IEnumerator EnemyWalk()
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
            animator.SetBool("isWalk", false);
            if (turnType == 0)
            {
                animator.SetBool("isTurn", true);
            }
            else if (turnType == 1)
            {
                animator.SetBool("isTurn2", true);
            }
            yield return new WaitForSeconds(3f);
        }
    }

    //추적
    IEnumerator StartTraking()
    {
        while (target != null)
        {
            if (state == State.Tracking)
            {
                animator.SetBool("isAttack", false);
                animator.SetBool("isAttack2", false);
                animator.SetBool("isRun", true);
                transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
            }
            else if (state == State.Attack)
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


}

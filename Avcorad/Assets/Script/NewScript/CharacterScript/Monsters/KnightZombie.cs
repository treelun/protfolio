using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightZombie : MonsterEntity
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
                    Debug.Log("몬스터의 상태가 Attack입니다.");
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

    int turnType;
    private void Awake()
    {
        
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        state = State.Move;
        moveSpeed = 1f;
    }
    private void Update()
    {
        Debug.Log(state);

    }
    //인식했을 때 반응(바로 공격할것인가? 쳐다보고 공격할 것인가)

    //공격패턴(후려치기, 찍기, 물기, 등등)
    public override void Attack()
    {
        base.Attack();
       
        animator.SetBool("isAttack", true);
        animator.SetBool("isAttack2", true);
        
    }

    //죽음(죽는 animation)
    //아이템, 경험치 drop(아이템드랍은 인터넷 참조 예상으로는 죽으면 > 비활성화된 아이템 프리펩 true로 바꾸고,
    //먹으면 비활성화, position은 몬스터의 위치로)

    //맞음(반짝이면서 hp감소)
    IEnumerator hitTest()
    {
        Debug.Log("몬스터 Hp : " + Hp);
        yield return new WaitForSeconds(5f);
        Hit(1f);
    }

    //일반적인 로밍
    IEnumerator EnemyWalk()
    {
        while(state == State.Move)
        {
            
            animator.SetBool("isAttack", false);
            animator.SetBool("isAttack2", false);
            animator.SetBool("isRun", false);
            animator.SetBool("isTurn", false);
            animator.SetBool("isTurn2", false);
            animator.SetBool("isWalk", true);
            Debug.Log("Walk Coroutine");
            yield return new WaitForSeconds(10f);
            turnType = Random.Range(0, 2);
            Debug.Log("is TurnType" + turnType);
            animator.SetBool("isWalk", false);
            if (turnType == 0)
            {
                animator.SetBool("isTurn", true);
            }
            else if(turnType == 1)
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

    IEnumerator AttackType()
    {


        yield return new WaitForSeconds(2f);
    }
}

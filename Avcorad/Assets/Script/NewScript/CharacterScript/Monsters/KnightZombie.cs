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
                    Debug.Log("������ ���°� Attack�Դϴ�.");
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
    //�ν����� �� ����(�ٷ� �����Ұ��ΰ�? �Ĵٺ��� ������ ���ΰ�)

    //��������(�ķ�ġ��, ���, ����, ���)
    public override void Attack()
    {
        base.Attack();
       
        animator.SetBool("isAttack", true);
        animator.SetBool("isAttack2", true);
        
    }

    //����(�״� animation)
    //������, ����ġ drop(�����۵���� ���ͳ� ���� �������δ� ������ > ��Ȱ��ȭ�� ������ ������ true�� �ٲٰ�,
    //������ ��Ȱ��ȭ, position�� ������ ��ġ��)

    //����(��¦�̸鼭 hp����)
    IEnumerator hitTest()
    {
        Debug.Log("���� Hp : " + Hp);
        yield return new WaitForSeconds(5f);
        Hit(1f);
    }

    //�Ϲ����� �ι�
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

    //����
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

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
                    target = null;
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

    protected GameObject dropObject;

    public Transform target;

    public CapsuleCollider capsuleCollider;
    public SphereCollider playerCheckCollier;

    int turnType;

    public override void Init()
    {
        base.Init();
        AttackForce = _Damage;
        AttackSpeed = _AttackSpeed;
        Hp = _Hp;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        Init();
        state = State.Move;
    }

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
    //�Ϲ����� �ι�
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
}

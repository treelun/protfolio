using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightZombie : MonsterEntity
{
    State _state;
    public State state
    {
        get { return _state; }
        set {
            switch (value)
            {
                case State.Attack:
                    Attack();
                    break;
                case State.Move:
                    Move();
                    StopCoroutine(StartTraking());
                    animator.SetBool("isRun", false);
                    break;
                case State.Death:
                    break;
                case State.Tracking:
                    StartCoroutine(StartTraking());
                    Traking();
                    break;
                default:
                    break;
            }
            _state = value;
        }
    }
    

    private void Start()
    {
        state = State.Move;
    }

    //���Ͱ� ������(�������� �Դ� ����)
    public override void Move()
    {
        base.Move();
        //GetComponent<Rigidbody>().MovePosition(transform.position);
        StartCoroutine(EnemyWalk());
    }
    //������ �ν� �ݰ�(spherecollier���)
    //�ν����� �� ����(�ٷ� �����Ұ��ΰ�? �Ĵٺ��� ������ ���ΰ�)
    void Traking()
    {
        animator.SetBool("isRun", true);
    }
    //��������(�ķ�ġ��, ���, ����, ���)
    //����(��¦�̸鼭 hp����)
    //����(�״� animation)
    //������, ����ġ drop(�����۵���� ���ͳ� ���� �������δ� ������ > ��Ȱ��ȭ�� ������ ������ true�� �ٲٰ�,
    //������ ��Ȱ��ȭ, position�� ������ ��ġ��)

    IEnumerator hitTest()
    {
        Debug.Log("���� Hp : " + Hp);
        yield return new WaitForSeconds(5f);
        Hit(1f);
    }

    IEnumerator EnemyWalk()
    {
        while(Mystate == State.Move)
        {
            animator.SetBool("isWalk", true);
            yield return new WaitForSeconds(20f);
            animator.SetBool("isWalk", false);
            animator.SetTrigger("turn");
        }
    }
    IEnumerator StartTraking()
    {
        while (target != null)
        {
            transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
            yield return null;
        }

    }
}

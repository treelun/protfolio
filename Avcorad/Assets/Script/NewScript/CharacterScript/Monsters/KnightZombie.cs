using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightZombie : MonsterEntity
{
    private void Start()
    {
        state = State.Move;
    }
    private void Update()
    {
        Debug.Log(state);
        
    }
    //�ν����� �� ����(�ٷ� �����Ұ��ΰ�? �Ĵٺ��� ������ ���ΰ�)

    //��������(�ķ�ġ��, ���, ����, ���)
/*    public override void Attack()
    {
        base.Attack();
       
        animator.SetBool("isAttack", true);
        animator.SetBool("isAttack2", true);
        
    }*/

    //����(�״� animation)
    //������, ����ġ drop(�����۵���� ���ͳ� ���� �������δ� ������ > ��Ȱ��ȭ�� ������ ������ true�� �ٲٰ�,
    //������ ��Ȱ��ȭ, position�� ������ ��ġ��)

    //����(��¦�̸鼭 hp����)
    //�Ϲ����� �ι�
    /*IEnumerator EnemyWalk()
    {
        while(true)
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

    }*/

}

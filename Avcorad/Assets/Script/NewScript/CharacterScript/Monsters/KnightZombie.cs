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

    //몬스터가 움직임(일정범위 왔다 갔다)
    public override void Move()
    {
        base.Move();
        //GetComponent<Rigidbody>().MovePosition(transform.position);
        StartCoroutine(EnemyWalk());
    }
    //몬스터의 인식 반경(spherecollier사용)
    //인식했을 때 반응(바로 공격할것인가? 쳐다보고 공격할 것인가)
    void Traking()
    {
        animator.SetBool("isRun", true);
    }
    //공격패턴(후려치기, 찍기, 물기, 등등)
    //맞음(반짝이면서 hp감소)
    //죽음(죽는 animation)
    //아이템, 경험치 drop(아이템드랍은 인터넷 참조 예상으로는 죽으면 > 비활성화된 아이템 프리펩 true로 바꾸고,
    //먹으면 비활성화, position은 몬스터의 위치로)

    IEnumerator hitTest()
    {
        Debug.Log("몬스터 Hp : " + Hp);
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

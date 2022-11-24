using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public PlayerEntity playerData;
    //ILivingEntity livingEntity;
    private void Update()
    {
        //���������� �̿��Ͽ� ���ݰ� ȸ���� �̵��� ���߰�, ���Ӱ����� ����
        //Attack�����϶� Ŭ���� ������ ������ �Լ��� ����
        switch (playerData.Mystate)
        {
            case PlayerEntity.State.Attack:
                if (Input.GetMouseButtonDown(0))
                {
                    playerData.Mystate = PlayerEntity.State.Attack;
                    playerData.Attack();
                }
                break;
            case PlayerEntity.State.Move:
                playerData.Move();
                if (Input.GetMouseButtonDown(0))
                {
                    playerData.Mystate = PlayerEntity.State.Attack;
                    playerData.Attack();
                }
                else if (Input.GetKey(KeyCode.LeftShift))
                {
                    playerData.Mystate = PlayerEntity.State.Dodge;
                    playerData.dodge();
                }
                else if (Input.GetButtonDown("Jump"))
                {
                    playerData.Jump();
                }
                break;
            case PlayerEntity.State.Interaction:
                if (Input.GetKey(KeyCode.Escape))
                {
                    playerData.Mystate = PlayerEntity.State.Move;
                }
                break;
            default:
                break;
        }
        Debug.Log(playerData.Mystate);
        playerData.Dead();
    }
    private void FixedUpdate()
    {
        
        playerData.playerLevelup();
        //Debug.Log("�÷��̾� Hp : " + playerData.Hp);
        //attack(),Move(),dodge(),Jump(),F(interaction)��ȣ�ۿ�Ű
    }
    void GetItem()
    {

    }

/*    void useItem(Item _item)
    {
        //������ ���
        item = _item;
        //item.useItem();
    }*/

    private void Init()
    {
        //��������, ������ �����ұ�?...��....
    }

}

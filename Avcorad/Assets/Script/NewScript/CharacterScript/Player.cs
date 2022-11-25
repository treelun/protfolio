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
            case LivingEntity.State.Attack:
                if (Input.GetMouseButtonDown(0))
                {
                    playerData.Mystate = LivingEntity.State.Attack;
                    playerData.Attack();
                }
                break;
            case LivingEntity.State.Move:
                playerData.Move();
                if (Input.GetMouseButtonDown(0) && playerData.curWeapon != null)
                {
                    playerData.Mystate = LivingEntity.State.Attack;
                    playerData.Attack();
                }
                else if (Input.GetKey(KeyCode.LeftShift))
                {
                    playerData.Mystate = LivingEntity.State.Dodge;
                    playerData.dodge();
                }
                else if (Input.GetButtonDown("Jump"))
                {
                    playerData.Jump();
                }
                break;
            case LivingEntity.State.Interaction:
                if (Input.GetKey(KeyCode.Escape))
                {
                    playerData.Mystate = LivingEntity.State.Move;
                }
                break;
            case LivingEntity.State.Death:

                break;
            default:
                break;
        }
        Debug.Log(playerData.Mystate);
        playerData.Death();
    }
    private void FixedUpdate()
    {
        playerData.playerLevelup();
        //GameManager.Instance.inventory.EquipWeapon();
        //Debug.Log("�÷��̾� Hp : " + playerData.Hp);
        //attack(),Move(),dodge(),Jump(),F(interaction)��ȣ�ۿ�Ű
        Debug.Log(playerData.curWeapon);
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

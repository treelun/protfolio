using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public PlayerEntity playerData;
    //ILivingEntity livingEntity;
    private void Update()
    {
        //상태패턴을 이용하여 공격과 회피중 이동을 멈추고, 연속공격을 위해
        //Attack상태일때 클릭시 공격이 나가는 함수를 적용
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
        //Debug.Log("플레이어 Hp : " + playerData.Hp);
        //attack(),Move(),dodge(),Jump(),F(interaction)상호작용키
        Debug.Log(playerData.curWeapon);
    }
    void GetItem()
    {

    }

/*    void useItem(Item _item)
    {
        //아이템 사용
        item = _item;
        //item.useItem();
    }*/

    private void Init()
    {
        //정보변경, 무었을 변경할까?...음....
    }

}

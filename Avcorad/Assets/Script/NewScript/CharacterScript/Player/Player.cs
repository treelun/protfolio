using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PlayerEntity playerData;
    //ILivingEntity livingEntity;
    public GameObject InteractionText;

    public Image dot;


    float delta;
    private void Update()
    {
        //상태패턴을 이용하여 공격과 회피중 이동을 멈추고, 연속공격을 위해
        //Attack상태일때 클릭시 공격이 나가는 함수를 적용
        switch (playerData.Mystate)
        {
            case PlayerEntity.State.Attack:
                transform.Rotate(0f, Input.GetAxis("Mouse X") * playerData._rotateSpeed, 0f, Space.World);
                if (Input.GetMouseButtonDown(0) && playerData.Sta > 0 && playerData.curWeapon != null)
                {
                    playerData.Attack();
                }
                break;
            case PlayerEntity.State.Move:
                playerData.Move();
                playerData.RegenSta();
                dot.enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
                if (Input.GetMouseButtonDown(0) && playerData.curWeapon != null && playerData.Sta > 0 && !playerData.isJump)
                {
                    playerData.Attack();
                }
                else if (Input.GetKey(KeyCode.LeftShift) && playerData.Sta > 0 && !playerData.isJump)
                {
                    playerData.Mystate = PlayerEntity.State.Dodge;
                    playerData.dodge();
                }
                else if (Input.GetButtonDown("Jump") && playerData.Sta > 0)
                {
                    playerData.Jump();
                }
                break;
            case PlayerEntity.State.Interaction:
                InteractionText.SetActive(false);
                dot.enabled = false;
                if (Input.GetKey(KeyCode.Escape))
                {
                    playerData.Mystate = PlayerEntity.State.Move;
                }
                break;
            case PlayerEntity.State.Death:
                break;
            case PlayerEntity.State.UseUi:
                playerData.RegenSta();
                dot.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                break;
            case PlayerEntity.State.Hit:
                break;
            default:
                break;
        }
        if (playerData.Hp <= float.Epsilon)
        {
            playerData.Mystate = PlayerEntity.State.Death;
        }

    }
    private void FixedUpdate()
    {
        playerData.playerLevelup();
    }

    private void Init()
    {
        //정보변경, 무었을 변경할까?...음....
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    public PlayerEntity playerData;
    //ILivingEntity livingEntity;
    public GameObject InteractionText;
    float delta;

    public Image dot;
    private void Update()
    {
        //���������� �̿��Ͽ� ���ݰ� ȸ���� �̵��� ���߰�, ���Ӱ����� ����
        //Attack�����϶� Ŭ���� ������ ������ �Լ��� ����
        switch (playerData.Mystate)
        {
            case LivingEntity.State.Attack:
                if (Input.GetMouseButtonDown(0) && playerData.Sta > 0 && playerData.curWeapon != null)
                {
                    playerData.Attack();
                }
                break;
            case LivingEntity.State.Move:
                playerData.Move();
                playerData.RegenSta();
                dot.enabled = true;
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                if (Input.GetMouseButtonDown(0) && playerData.curWeapon != null && playerData.Sta > 0 && !playerData.isJump)
                {
                    playerData.Attack();
                }
                else if (Input.GetKey(KeyCode.LeftShift) && playerData.Sta > 0 && !playerData.isJump)
                {
                    playerData.Mystate = LivingEntity.State.Dodge;
                    playerData.dodge();
                }
                else if (Input.GetButtonDown("Jump") && playerData.Sta > 0)
                {
                    playerData.Jump();
                }
                break;
            case LivingEntity.State.Interaction:
                Cursor.lockState = CursorLockMode.None;
                InteractionText.SetActive(false);
                if (Input.GetKey(KeyCode.Escape))
                {
                    playerData.Mystate = LivingEntity.State.Move;
                }
                break;
            case LivingEntity.State.Death:

                break;
            case LivingEntity.State.UseUi:
                playerData.RegenSta();
                Time.timeScale = 0f;
                dot.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                break;
            default:
                break;
        }
        Debug.Log(playerData.Mystate);

        
        playerData.Death();
    }
    private void FixedUpdate()
    {
        //attack(),Move(),dodge(),Jump(),F(interaction)��ȣ�ۿ�Ű
        playerData.playerLevelup();
        delta += Time.deltaTime;
        if (delta > 1)
        {
            playerData.currentExp += 1000;
            delta = 0;
        }
    }

    private void Init()
    {
        //��������, ������ �����ұ�?...��....
    }

}

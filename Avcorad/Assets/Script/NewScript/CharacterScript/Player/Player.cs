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
        Debug.Log(playerData.Mystate);
        //���������� �̿��Ͽ� ���ݰ� ȸ���� �̵��� ���߰�, ���Ӱ����� ����
        //Attack�����϶� Ŭ���� ������ ������ �Լ��� ����
        switch (playerData.Mystate)
        {
            case PlayerEntity.State.Attack:
                if (Input.GetMouseButtonDown(0) && playerData.Sta > 0 && playerData.curWeapon != null)
                {
                    playerData.Attack();
                }
                break;
            case PlayerEntity.State.Move:
                playerData.Move();
                playerData.RegenSta();
                dot.enabled = true;
                //Cursor.visible = false;
                //Cursor.lockState = CursorLockMode.Locked;
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
                playerData.Death();
                break;
            case PlayerEntity.State.UseUi:
                playerData.RegenSta();
                dot.enabled = false;
                //Cursor.visible = true;
                //Cursor.lockState = CursorLockMode.Confined;
                break;
            default:
                break;
        }
        if (playerData.Hp <= float.Epsilon)
        {
            playerData.Mystate = PlayerEntity.State.Death;
        }
        transform.Rotate(0f, Input.GetAxis("Mouse X") * playerData._rotateSpeed, 0f, Space.World);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "EnemyAttackBox")
        {
            //playerData.Hit(other.GetComponentInParent<MonsterEntity>().AttackForce);
            playerData.Hit(0.1f);
            //Debug.Log("Hit the Player");
        }
    }
}

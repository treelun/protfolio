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
        //상태패턴을 이용하여 공격과 회피중 이동을 멈추고, 연속공격을 위해
        //Attack상태일때 클릭시 공격이 나가는 함수를 적용
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
                //Cursor.visible = false;
                //Cursor.lockState = CursorLockMode.Locked;
                //Time.timeScale = 1f;
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
                InteractionText.SetActive(false);
                dot.enabled = false;
                if (Input.GetKey(KeyCode.Escape))
                {
                    playerData.Mystate = LivingEntity.State.Move;
                }
                break;
            case LivingEntity.State.Death:
                playerData.Death();
                break;
            case LivingEntity.State.UseUi:
                playerData.RegenSta();
                dot.enabled = false;
                //Time.timeScale = 0;
                //Cursor.visible = true;
                //Cursor.lockState = CursorLockMode.Confined;
                break;
            default:
                break;
        }
        if (playerData.Hp <= float.Epsilon)
        {
            playerData.Mystate = LivingEntity.State.Death;
        }
        transform.Rotate(0f, Input.GetAxis("Mouse X") * playerData._rotateSpeed, 0f, Space.World);
    }
    private void FixedUpdate()
    {
        //attack(),Move(),dodge(),Jump(),F(interaction)상호작용키
        playerData.playerLevelup();
/*        delta += Time.deltaTime;
        if (delta > 1)
        {
            playerData.currentExp += 1000;
            delta = 0;
        }*/
    }

    private void Init()
    {
        //정보변경, 무었을 변경할까?...음....
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "EnemyAttackBox")
        {
            //playerData.Hit(other.GetComponentInParent<MonsterEntity>().AttackForce);
            playerData.Hit(0.1f);
            Debug.Log("Hit the Player");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerEntity playerData;
    Iitem item;
    //ILivingEntity livingEntity;

    private void Update()
    {
        playerData.dodge();
        playerData.Jump();
        playerData.Attack();
    }
    private void FixedUpdate()
    {
        playerData.Move();
        playerData.Dead();
        
        playerData.UpdatePlayerData();
        //Debug.Log("플레이어 Hp : " + playerData.Hp);
        //attack(),Move(),dodge(),Jump(),F(interaction)상호작용키
    }
    void GetItem()
    {
        //아이템 획득
    }
    void useItem(Iitem _item)
    {
        //아이템 사용
        item = _item;
        item.useItem();
    }

    private void Init()
    {
        //정보변경, 무었을 변경할까?...음....
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
        {
            useItem(other.GetComponent<Iitem>());
            //iteminfo = other.GetComponent<Iitem>();
            Debug.Log(other.GetComponent<Iitem>());
        }
    }
}

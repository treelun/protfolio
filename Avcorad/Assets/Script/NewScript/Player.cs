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
        //Debug.Log("�÷��̾� Hp : " + playerData.Hp);
        //attack(),Move(),dodge(),Jump(),F(interaction)��ȣ�ۿ�Ű
    }
    void GetItem()
    {
        //������ ȹ��
    }
    void useItem(Iitem _item)
    {
        //������ ���
        item = _item;
        item.useItem();
    }

    private void Init()
    {
        //��������, ������ �����ұ�?...��....
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

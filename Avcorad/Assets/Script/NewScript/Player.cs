using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerEntity playerEntity;
    Iitem iteminfo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //attack(),Move(),dodge(),Jump(),F(interaction)��ȣ�ۿ�Ű
    }

    void GetItem()
    {
        //������ ȹ��
    }
    void useItem(Iitem _item)
    {
        //������ ���
        _item.useItem();
    }
}

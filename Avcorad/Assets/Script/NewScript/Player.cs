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
        //attack(),Move(),dodge(),Jump(),F(interaction)상호작용키
    }

    void GetItem()
    {
        //아이템 획득
    }
    void useItem(Iitem _item)
    {
        //아이템 사용
        _item.useItem();
    }
}

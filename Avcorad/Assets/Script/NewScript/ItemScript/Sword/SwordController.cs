using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public Iitem iitem;


    float delta;
    // Start is called before the first frame update
    void Start()
    {
        iitem.Init();
        //GameManager.Instance.mainPlayer.playerData.curWeapon = iitem;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.mainPlayer.playerData.curWeapon != iitem)
        {
            //GameManager.Instance.mainPlayer.playerData.curWeapon.unuseItem();
            //GameManager.Instance.mainPlayer.playerData.curWeapon = iitem;
            iitem.Init();
        }
        delta += Time.deltaTime;
        if (delta > 10f)
        {
            iitem.useItem();
            delta = 0;
        }
        
    }
}

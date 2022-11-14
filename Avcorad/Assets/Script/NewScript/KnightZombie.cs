using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightZombie : MonsterEntity
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(hitTest());
    }

    IEnumerator hitTest()
    {
        Debug.Log("∏ÛΩ∫≈Õ Hp : " + Hp);
        yield return new WaitForSeconds(5f);
        Hit(1f);
    }
}

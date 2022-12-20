using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    GameObject enemy;

    [SerializeField] ItemBox itembox;

    float delta;
    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > 3f)
        {
            CreateEnemy();
            delta = 0;
        }
        
    }

    void CreateEnemy()
    {
        enemy 
         = Instantiate(enemyPrefab, transform.position, transform.rotation);

        if(!GameManager.Instance.itembox)
        {
            return;
        }

        GameManager.Instance.itembox = this.itembox;
    }


}

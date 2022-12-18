using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    GameObject enemy;

    [SerializeField] ItemBox itembox;


    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            CreateEnemy();
        }
        
    }

    void CreateEnemy()
    {
        enemy 
         = Instantiate(enemyPrefab, transform.position, transform.rotation);

        if(!enemy.TryGetComponent<MonsterEntity>(out var monsterEntity))
        {
            return;
        }

        monsterEntity.itembox = this.itembox;
    }


}

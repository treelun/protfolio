using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject bossPrefab;
    GameObject enemy;

    [SerializeField] ItemBox itembox;
    void CreateEnemy()
    {
        enemy
         = Instantiate(bossPrefab, transform.position, transform.rotation);


        if (!GameManager.Instance.itembox)
        {
            return;
        }

        GameManager.Instance.itembox = this.itembox;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (enemy == null)
            {
                CreateEnemy();
            }
        }
    }
}

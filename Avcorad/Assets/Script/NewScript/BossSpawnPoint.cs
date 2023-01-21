using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnPoint : MonoBehaviour
{
    public GameObject bossPrefab;
    GameObject enemy;

    void CreateEnemy()
    {
        enemy
         = Instantiate(bossPrefab, transform.position, transform.rotation);

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

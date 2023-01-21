using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject enemyPrefab;
    GameObject enemy;

    float delta;

    private void Start()
    {
        CreateEnemy();
    }
    // Update is called once per frame
    void Update()
    {

        if (enemy.activeSelf == false)
        {
            StartCoroutine(CreateEnemyCoroutine());
        }
        else
        {
            return;
        }

    }

    public GameObject CreateEnemy()
    {
        if (enemyPrefab != null)
        {
            enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            return enemy;
        }

        return null;

    }
    IEnumerator CreateEnemyCoroutine()
    {
        yield return new WaitForSeconds(5f);
        enemy.SetActive(true);
    }

}

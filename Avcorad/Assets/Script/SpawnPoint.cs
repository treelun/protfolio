using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    GameObject enemy;

    [SerializeField] ItemBox itembox;

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
    IEnumerator CreateEnemyCoroutine()
    {
        yield return new WaitForSeconds(5f);
        enemy.SetActive(true);
    }

}

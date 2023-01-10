using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    GameObject player;


    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            CreateEnemy();
        }

    }

    void CreateEnemy()
    {
        player
         = Instantiate(playerPrefab, transform.position, transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    GameObject PlayerMove;


    // Update is called once per frame
    void Update()
    {
        if (PlayerMove == null)
        {
            CreateEnemy();
        }

    }

    void CreateEnemy()
    {
        PlayerMove
         = Instantiate(playerPrefab, transform.position, transform.rotation);
    }
}

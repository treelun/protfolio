using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public List<GameObject> itemPrefabs;

    public void DropItem()
    {
        int ranNum = Random.Range(0, 3);
       
        GameObject item = Instantiate(itemPrefabs[ranNum], transform.position, itemPrefabs[ranNum].transform.rotation);
    }
}

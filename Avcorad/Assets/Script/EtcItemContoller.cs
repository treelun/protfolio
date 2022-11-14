using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtcItemContoller : MonoBehaviour
{
    public List<GameObject> itemPrefabs;
    public ItemData itemData;

    public enum ItemName
    {
        Heart,
        GreenCoin,
        YellowCoin
    }
    public ItemName itemname = ItemName.Heart;
    public void DropItem()
    {
        int ranNum = Random.Range(0, 3);

        GameObject item = Instantiate(itemPrefabs[ranNum], transform.position, itemPrefabs[ranNum].transform.rotation);
    }
    public void GetItem(GameObject _gameObject)
    {

    }
}

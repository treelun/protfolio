using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject HpPotion;
    public GameObject MpPotion;
    public GameObject stoneSword;
    public GameObject worldofSword;
    public GameObject sparkSword;
    public GameObject flameSword;
    public GameObject steelSword;
    List<GameObject> HpPotionPrefab = new List<GameObject>();
    List<GameObject> MpPotionPrefab = new List<GameObject>();
    GameObject dropItem;

    public void SetObject(Vector3 spwanTransform)
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject hpPotions = Instantiate(HpPotion, spwanTransform , Quaternion.identity);
            hpPotions.gameObject.SetActive(false);
            hpPotions.gameObject.transform.SetParent(this.transform);
            HpPotionPrefab.Add(hpPotions);
            GameObject mpPotions = Instantiate(MpPotion, spwanTransform, Quaternion.identity);
            mpPotions.gameObject.SetActive(false);
            mpPotions.gameObject.transform.SetParent(this.transform);
            MpPotionPrefab.Add(mpPotions);
        }
    }

    public GameObject GetHpPotion(int i)
    {
        dropItem = HpPotionPrefab[i];
       
        return dropItem;
    }

    public GameObject GetMpPotion(int i)
    {
        dropItem = MpPotionPrefab[i];

        return dropItem;
    }

    public GameObject Getweapon(Vector3 spwanTransform)
    {
        int rand = Random.Range(0, 101);
        if (rand < 50)
        {
            dropItem = Instantiate(stoneSword, spwanTransform, Quaternion.identity);
        }
        else if (50 <= rand && rand < 70)
        {
            dropItem = Instantiate(steelSword, spwanTransform, Quaternion.identity);
        }
        else if (70 <= rand && rand < 80)
        {
            dropItem = Instantiate(flameSword, spwanTransform, Quaternion.identity);
        }
        else if (80 <= rand && rand < 97)
        {
            dropItem = Instantiate(sparkSword, spwanTransform, Quaternion.identity);
        }
        else if (97 <= rand && rand < 100)
        {
            dropItem = Instantiate(worldofSword, spwanTransform, Quaternion.identity);
        }
        return dropItem;
    }

}

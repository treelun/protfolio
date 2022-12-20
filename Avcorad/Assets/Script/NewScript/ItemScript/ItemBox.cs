using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject HpPotion;
    public GameObject MpPotion;
    List<GameObject> HpPotionPrefab = new List<GameObject>();
    List<GameObject> MpPotionPrefab = new List<GameObject>();
    GameObject dropItem;

    public void SetObject(Vector3 spwanTransform)
    {
        for (int i = 0; i < 5; i++)
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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject HpPotion;
    public GameObject MpPotion;
    List<GameObject> PotionPrefab = new List<GameObject>();

    public void Awake()
    {
        SetObject();
    }

    public void SetObject()
    {
        if(PotionPrefab.Count <= 0)
        {
            GameObject hpPotions = Instantiate(HpPotion);
            PotionPrefab.Add(hpPotions);
            GameObject mpPotions = Instantiate(MpPotion);
            PotionPrefab.Add(mpPotions);
        }
    }

    public GameObject GetObject(int i)
    {
        SetObject();
        return PotionPrefab[i];
    }

    public int GetListCount()
    {
        return PotionPrefab.Count;
    }
}

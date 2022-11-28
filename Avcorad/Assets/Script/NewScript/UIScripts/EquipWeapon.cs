using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipWeapon : MonoBehaviour
{
    public List<GameObject> WeaponPrefab;
    public List<GameObject> _WeaponPrefab;

    private void Awake()
    {
        SlotAddWeapon();
    }

    public void SlotAddWeapon()
    {
        for (int i = 0; i < WeaponPrefab.Count && i < _WeaponPrefab.Count; i++)
        {
            _WeaponPrefab[i] = Instantiate(WeaponPrefab[i],this.transform);
            _WeaponPrefab[i].GetComponent<RectTransform>().position = this.transform.position;
            _WeaponPrefab[i].SetActive(false);
        }
    }
}

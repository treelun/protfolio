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

    public void ActiveWeapon(bool _active)
    {
        for (int i = 0; i < _WeaponPrefab.Count && i < GameManager.Instance.inventory.inventory.Count; i++)
        {
            if (_WeaponPrefab[i].GetComponent<ItemInfo>().item == GameManager.Instance.inventory.inventory[i].item)
            {
                _WeaponPrefab[i].SetActive(_active);
                
            }
        }
        
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

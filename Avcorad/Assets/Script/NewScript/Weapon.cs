using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, Iitem
{
    public enum WeaponType { basicWeapon, SecondWeapon }
    public WeaponType weaponType;

    public float AttackForce { get; set; }
    public float AttackSpeed { get; set; }
    public ParticleSystem hitparticle;
    public ParticleSystem swingparticle;

    public void useItem()
    {
        //플레이어의 무기데이터 업데이트
        if (weaponType == WeaponType.basicWeapon)
        {
            AttackForce = 10;
            AttackSpeed = 2;
        }
    }
    private void OnEnable()
    {
        useItem();
    }
}

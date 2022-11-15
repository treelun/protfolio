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
        //�÷��̾��� ���ⵥ���� ������Ʈ
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

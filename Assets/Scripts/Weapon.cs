using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public WeaponUpgradeData currentWeaponData;

    private float _nextShot;
    private AudioClipGroup _sound;

    private void Awake()
    {
        Events.OnSelectWeapon += OnSelectWeapon;
        Events.OnGetSelectedWeaponData += OnGetSelectedWeaponData;
    }
    private void OnDestroy()
    {
        Events.OnSelectWeapon -= OnSelectWeapon;
        Events.OnGetSelectedWeaponData -= OnGetSelectedWeaponData;
    }

    private WeaponUpgradeData OnGetSelectedWeaponData()
    {
        return currentWeaponData;
    }

    private void OnSelectWeapon(WeaponUpgradeData data)
    {
        currentWeaponData = data;
        _nextShot = Time.time;
        _sound = data.sound;
    }

    void Start()
    {
        _nextShot = Time.time;
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time >= _nextShot)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        _nextShot = Time.time + currentWeaponData.shootingSpeed;
        _sound.Play();
        
        for (int i = 0; i < currentWeaponData.bulletAmount; i++)
        {
            //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            float bulletRotNorm = Random.Range(-currentWeaponData.bullerSpread / 180, currentWeaponData.bullerSpread /
                180);
            Quaternion bulletRot = Quaternion.FromToRotation(new Vector3(1, bulletRotNorm, 0), firePoint.right);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, bulletRot);
            bullet.GetComponent<Bullet>().speed = currentWeaponData.bulletSpeed;
            bullet.GetComponent<Bullet>().bulletColor = currentWeaponData.bulletColor;
            bullet.GetComponent<Bullet>().damage = currentWeaponData.damage;
        }
    }
}
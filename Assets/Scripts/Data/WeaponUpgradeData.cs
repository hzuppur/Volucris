using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Volucris/WeaponUpgrade")]
public class WeaponUpgradeData : ScriptableObject
{
    public string weaponName;
    public float shootingSpeed = 2f;
    public float bulletSpeed = 20f;
    public int damage = 1;
    public Sprite sprite;
    public int bulletAmount = 1;
    public float bullerSpread = 0f;
    public AudioClipGroup sound;
    public Color bulletColor = Color.white;
}

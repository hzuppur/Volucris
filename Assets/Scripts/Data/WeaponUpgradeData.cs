using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Volucris/WeaponUpgrade")]
public class WeaponUpgradeData : ScriptableObject
{
    public float shootingSpeed = 2f;
    public float damage = 1f;
    public Sprite sprite;
    public int bulletAmount = 1;
    public float bullerSpread = 0f;
}

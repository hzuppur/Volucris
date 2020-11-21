using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static event Func<Transform> OnGetPlayerPos;
    public static Transform GetPlayerPos() => OnGetPlayerPos?.Invoke();
    
    public static event Func<Transform> OnGetCameraPos;
    public static Transform GetCameraPos() => OnGetCameraPos?.Invoke();
    
    public static event Action OnRestart;
    public static void Restart() => OnRestart?.Invoke();
    
    public static event Action OnPlayerDeath;
    public static void PlayerDeath() => OnPlayerDeath?.Invoke();
    
    public static event Action OnPlayerWin;
    public static void PlayerWin() => OnPlayerWin?.Invoke();
    
    public static event Action<WeaponUpgradeData> OnWeaponUpgradePickup;
    public static void WeaponUpgradePickup(WeaponUpgradeData weaponUpgradeData) => OnWeaponUpgradePickup?.Invoke(weaponUpgradeData);
    
    public static event Action<WeaponUpgradeData> OnSelectWeapon;
    public static void SelectWeapon(WeaponUpgradeData data) => OnSelectWeapon?.Invoke(data);
    
    public static event Func<WeaponUpgradeData> OnGetSelectedWeaponData;
    public static WeaponUpgradeData GetSelectedWeaponData() => OnGetSelectedWeaponData?.Invoke();
}

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

    public static event Action OnPlayerFinishLevel;
    public static void PlayerFinishLevel() => OnPlayerFinishLevel?.Invoke();

    public static event Action<WeaponUpgradeData, string> OnWeaponUpgradePickup;

    public static void WeaponUpgradePickup(WeaponUpgradeData weaponUpgradeData, string name) =>
        OnWeaponUpgradePickup?.Invoke(weaponUpgradeData, name);

    public static event Action<WeaponUpgradeData> OnSelectWeapon;
    public static void SelectWeapon(WeaponUpgradeData data) => OnSelectWeapon?.Invoke(data);

    public static event Func<WeaponUpgradeData> OnGetSelectedWeaponData;
    public static WeaponUpgradeData GetSelectedWeaponData() => OnGetSelectedWeaponData?.Invoke();

    public static event Action<string> OnSaveGame;
    public static void SaveGame(string name) => OnSaveGame?.Invoke(name);

    public static event Action OnLoadCheckpoint;
    public static void LoadCheckpoint() => OnLoadCheckpoint?.Invoke();

    public static event Func<List<WeaponUpgradeData>> OnGetInventory;
    public static List<WeaponUpgradeData> GetInventory() => OnGetInventory?.Invoke();

    public static event Action<List<WeaponUpgradeData>> OnSetInventory;
    public static void SetInventory(List<WeaponUpgradeData> data) => OnSetInventory?.Invoke(data);
    
    public static event Func<int> OnGetPlayerHealth;
    public static int GetPlayerHealth() => OnGetPlayerHealth?.Invoke() ?? 100;
    
    public static event Action<int> OnSetPlayerHealth;
    public static void SetPlayerHealth(int data) => OnSetPlayerHealth?.Invoke(data);
    
    public static event Action<string> OnEnemyKilled;
    public static void EnemyKilled(string data) => OnEnemyKilled?.Invoke(data);
    
    public static event Func<List<string>> OnGetEnemiesKilled;
    public static List<string> GetEnemiesKilled() => OnGetEnemiesKilled?.Invoke();
    
    public static event Func<List<string>> OnGetWeaponUpgradePickups;
    public static List<string> GetWeaponUpgradePickups() => OnGetWeaponUpgradePickups?.Invoke();
    
    public static event Action<string> OnDoorOpened;
    public static void DoorOpened(string data) => OnDoorOpened?.Invoke(data);
    
    public static event Func<List<string>> OnGetDoorOpened;
    public static List<string> GetDoorOpened() => OnGetDoorOpened?.Invoke();
}
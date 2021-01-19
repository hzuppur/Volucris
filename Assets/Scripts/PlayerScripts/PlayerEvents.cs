using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    private List<string> _enemiesKilled = new List<string>();
    private List<string> _weaponsCollected = new List<string>();

    private void Awake()
    {
        Events.OnGetPlayerPos += OnGetPlayerPos;
        Events.OnEnemyKilled += OnEnemyKilled;
        Events.OnGetEnemiesKilled += OnGetEnemiesKilled;
        Events.OnWeaponUpgradePickup += OnWeaponUpgradePickup;
        Events.OnGetWeaponUpgradePickups += OnGetWeaponUpgradePickups;
    }

    private void OnDestroy()
    {
        Events.OnGetPlayerPos -= OnGetPlayerPos;
        Events.OnEnemyKilled -= OnEnemyKilled;
        Events.OnGetEnemiesKilled -= OnGetEnemiesKilled;
        Events.OnWeaponUpgradePickup -= OnWeaponUpgradePickup;
        Events.OnGetWeaponUpgradePickups -= OnGetWeaponUpgradePickups;
    }

    private void Start()
    {
        if (SaveManager.Instance.hasLoaded)
        {
            gameObject.transform.position = SaveManager.Instance.activeSave.respawnPosition;
            Events.SetInventory(SaveManager.Instance.GetInventory());
            Events.SelectWeapon(SaveManager.Instance.GetActiveWeapon());
            Events.SetPlayerHealth(SaveManager.Instance.activeSave.playerHealth);
            _enemiesKilled = SaveManager.Instance.activeSave.enemiesKilled;
            _weaponsCollected = SaveManager.Instance.activeSave.weaponsCollected;

            foreach (var enemy in _enemiesKilled)
            {
                Destroy(GameObject.Find(enemy));
            }

            foreach (var weapon in _weaponsCollected)
            {
                Destroy(GameObject.Find(weapon));
            }
        }
        else
        {
            Events.SaveGame();
        }
    }

    private Transform OnGetPlayerPos()
    {
        return transform;
    }

    private void OnEnemyKilled(string data)
    {
        _enemiesKilled.Add(data);
    }

    private List<string> OnGetEnemiesKilled()
    {
        return _enemiesKilled;
    }

    private void OnWeaponUpgradePickup(WeaponUpgradeData _, string weaponName)
    {
        _weaponsCollected.Add(weaponName);
    }

    private List<string> OnGetWeaponUpgradePickups()
    {
        return _weaponsCollected;
    }
}
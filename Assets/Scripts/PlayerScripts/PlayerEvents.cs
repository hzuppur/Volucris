using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    private List<string> _enemiesKilled = new List<string>();
    private List<string> _weaponsCollected = new List<string>();
    private List<string> _doorsOpened = new List<string>();

    private void Awake()
    {
        Events.OnGetPlayerPos += OnGetPlayerPos;
        Events.OnEnemyKilled += OnEnemyKilled;
        Events.OnGetEnemiesKilled += OnGetEnemiesKilled;
        Events.OnWeaponUpgradePickup += OnWeaponUpgradePickup;
        Events.OnGetWeaponUpgradePickups += OnGetWeaponUpgradePickups;
        Events.OnGetDoorOpened += OnGetDoorOpened;
        Events.OnDoorOpened += OnDoorOpened;
    }

    private void OnDestroy()
    {
        Events.OnGetPlayerPos -= OnGetPlayerPos;
        Events.OnEnemyKilled -= OnEnemyKilled;
        Events.OnGetEnemiesKilled -= OnGetEnemiesKilled;
        Events.OnWeaponUpgradePickup -= OnWeaponUpgradePickup;
        Events.OnGetWeaponUpgradePickups -= OnGetWeaponUpgradePickups;
        Events.OnGetDoorOpened -= OnGetDoorOpened;
        Events.OnDoorOpened -= OnDoorOpened;
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
            _doorsOpened = SaveManager.Instance.activeSave.doorsOpened;

            DestroyAllInList(_enemiesKilled, false);
            DestroyAllInList(_weaponsCollected, false);
            DestroyAllInList(_doorsOpened, false);
            DestroyAllInList(SaveManager.Instance.activeSave.savePointsCollected, true);
        }
        else
        {
            Events.SaveGame("");
        }
    }

    private void DestroyAllInList(List<string> list, bool hitboxOnly)
    {
        foreach (var item in list)
        {
            if (hitboxOnly)
            {
                Destroy(GameObject.Find(item).GetComponent<BoxCollider2D>());
            }
            else
            {
                Destroy(GameObject.Find(item));
            }
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

    private void OnDoorOpened(string door)
    {
        _doorsOpened.Add(door);
    }

    private List<string> OnGetDoorOpened()
    {
        return _doorsOpened;
    }
}
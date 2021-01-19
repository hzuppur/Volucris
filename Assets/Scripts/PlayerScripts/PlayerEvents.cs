using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    private List<string> _enemiesKilled = new List<string>();
    
    private void Awake()
    {
        Events.OnGetPlayerPos += OnGetPlayerPos;
        Events.OnEnemyKilled += OnEnemyKilled;
        Events.OnGetEnemiesKilled += OnGetEnemiesKilled;
    }
    
    private void OnDestroy()
    {
        Events.OnGetPlayerPos -= OnGetPlayerPos;
        Events.OnEnemyKilled -= OnEnemyKilled;
        Events.OnGetEnemiesKilled -= OnGetEnemiesKilled;
    }

    private void Start()
    {
        if (SaveManager.Instance.hasLoaded)
        {
            gameObject.transform.position = SaveManager.Instance.activeSave.respawnPosition;
            Events.SetInventory(SaveManager.Instance.GetInventory());
            Events.SelectWeapon(SaveManager.Instance.GetActiveWeapon());
            Events.SetPlayerHealth(SaveManager.Instance.activeSave.playerHealth);

            foreach (var enemy in SaveManager.Instance.activeSave.enemiesKilled)
            {
                Destroy(GameObject.Find(enemy));
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
}

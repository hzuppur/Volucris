using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InvetoryPresenter : MonoBehaviour
{
    public Button weaponSelectPrefab;
    public WeaponUpgradeData baseWeapon;

    private List<WeaponUpgradeData> _inventoryContents;

    private void Awake()
    {
        Events.OnWeaponUpgradePickup += OnWeaponUpgradePickup;
        Events.OnGetInventory += GetInventory;
        Events.OnSetInventory += SetInventory;
    }
    
    private void OnDestroy()
    {
        Events.OnWeaponUpgradePickup -= OnWeaponUpgradePickup;
        Events.OnGetInventory -= GetInventory;
        Events.OnSetInventory -= SetInventory;
    }

    private void Start()
    {
        if (SaveManager.Instance.hasLoaded)
        {
            _inventoryContents = SaveManager.Instance.GetInventory();
            Events.SelectWeapon(SaveManager.Instance.GetActiveWeapon());
        }
        else
        {
            _inventoryContents = new List<WeaponUpgradeData>();
            _inventoryContents.Add(baseWeapon);
            Events.SelectWeapon(baseWeapon);
        }
        RefreshInventory();
    }

    private void Update()
    {
        int pressed = GetPressedNumber();
        if (pressed != -1 && pressed <= _inventoryContents.Count)
        {
            Events.SelectWeapon(_inventoryContents[pressed-1]);
        }
    }

    private void OnWeaponUpgradePickup(WeaponUpgradeData data)
    {
        if (_inventoryContents.Contains(data)) return;
        
        _inventoryContents.Add(data);

        RefreshInventory();
    }

    private void RefreshInventory()
    {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        foreach (WeaponUpgradeData weaponData in _inventoryContents)
        {
            Button weaponButton = Instantiate(weaponSelectPrefab, gameObject.transform);
            weaponButton.GetComponent<WeaponPresenter>().weaponUpgradeData = weaponData;
        }
    }
    
    private int GetPressedNumber() {
        for (int number = 0; number <= 9; number++) {
            if (Input.GetKeyDown(number.ToString()))
                return number;
        }
 
        return -1;
    }

    private void HideInventory()
    {
        gameObject.SetActive(false);
    }

    private List<WeaponUpgradeData> GetInventory()
    {
        return _inventoryContents;
    }
    
    private void SetInventory(List<WeaponUpgradeData> data)
    {
        _inventoryContents = data;
    }
}

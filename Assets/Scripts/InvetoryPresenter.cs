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

    private List<WeaponUpgradeData> inventoryContents;

    private void Awake()
    {
        Events.OnWeaponUpgradePickup += OnWeaponUpgradePickup;
    }
    
    private void OnDestroy()
    {
        Events.OnWeaponUpgradePickup -= OnWeaponUpgradePickup;
    }

    private void Start()
    {
        inventoryContents = new List<WeaponUpgradeData>();
        inventoryContents.Add(baseWeapon);
        RefreshInventory();
        Events.SelectWeapon(baseWeapon);
    }

    private void Update()
    {
        int pressed = GetPressedNumber();
        if (pressed != -1 && pressed <= inventoryContents.Count)
        {
            Events.SelectWeapon(inventoryContents[pressed-1]);
        }
    }

    private void OnWeaponUpgradePickup(WeaponUpgradeData data)
    {
        if (inventoryContents.Contains(data)) return;
        
        inventoryContents.Add(data);

        RefreshInventory();
    }

    private void RefreshInventory()
    {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        foreach (WeaponUpgradeData weaponData in inventoryContents)
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
}

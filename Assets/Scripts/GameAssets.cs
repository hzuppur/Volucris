using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _instance;

    public static GameAssets Instance => _instance;

    public  WeaponUpgradeData fastBlasterData;

    public  WeaponUpgradeData shotgunData;

    private void Awake()
    {
        _instance = this;
    }

    public void AddFastBlaster()
    {
        Events.WeaponUpgradePickup(fastBlasterData, "");
    }
    
    public void AddShotgun()
    {
        Events.WeaponUpgradePickup(shotgunData, "");
    }
}

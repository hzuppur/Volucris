using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public List<WeaponUpgradeData> weaponUpgradeData;
    private readonly Dictionary<string, WeaponUpgradeData> _weaponUpgradeDict = new Dictionary<string, WeaponUpgradeData>();

    public SaveData activeSave = new SaveData();

    public bool hasLoaded;

    private void Awake()
    {
        if (SaveManager.Instance != null)
        {
            Destroy(gameObject);
        }
        
        Instance = this;
        activeSave.saveName = "save1";
        foreach (var weapon in weaponUpgradeData)
        {
            _weaponUpgradeDict.Add(weapon.weaponName, weapon);
        }

        Load();

        Events.OnSaveGame += Save;
        Events.OnLoadCheckpoint += Load;
        
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        Events.OnSaveGame -= Save;
        Events.OnLoadCheckpoint -= Load;
    }

    private void Save(string savePointName)
    {
        string dataPath = Application.persistentDataPath;

        activeSave.respawnPosition = Events.GetPlayerPos().position;
        activeSave.inventoryContents = Events.GetInventory() != null
            ? Events.GetInventory().Select(weapon => weapon.weaponName).ToList()
            : new List<string>() {"BaseWeapon"};
        
        activeSave.currentWeapon = Events.GetSelectedWeaponData().weaponName;
        activeSave.playerHealth = Events.GetPlayerHealth();
        activeSave.level = SceneManager.GetActiveScene().name;
        activeSave.enemiesKilled = Events.GetEnemiesKilled();
        activeSave.weaponsCollected = Events.GetWeaponUpgradePickups();
        activeSave.doorsOpened = Events.GetDoorOpened();

        if (savePointName != "")
        {
            activeSave.savePointsCollected.Add(savePointName);
        }

        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + "save1" + ".save", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();

        Debug.Log("Saved");
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;

        if (!System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save")) return;

        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open);
        activeSave = serializer.Deserialize(stream) as SaveData;
        stream.Close();

        Events.Restart();

        hasLoaded = true;
        
        Debug.Log("Loaded");
    }

    public void DeleteSaveData()
    {
        string dataPath = Application.persistentDataPath;

        if (!System.IO.File.Exists(dataPath + "/" + "save1" + ".save")) return;

        File.Delete(dataPath + "/" + "save1" + ".save");

        hasLoaded = false;
        
        activeSave = new SaveData();

        Debug.Log("Deleted");
    }

    public WeaponUpgradeData GetActiveWeapon()
    {
        return _weaponUpgradeDict[activeSave.currentWeapon];
    }

    public List<WeaponUpgradeData> GetInventory()
    {
        return activeSave.inventoryContents.Select(weapon => _weaponUpgradeDict[weapon]).ToList();
    }

    public void RemoveLevelInfo(Vector3 respawnPosition)
    {
        SaveData newData = new SaveData
        {
            currentWeapon = activeSave.currentWeapon,
            inventoryContents = activeSave.inventoryContents,
            respawnPosition = respawnPosition,
            level = SceneManager.GetActiveScene().name,
            saveName = activeSave.saveName,
            playerHealth = activeSave.playerHealth
        };

        activeSave = newData;
        
        string dataPath = Application.persistentDataPath;
        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();

        Debug.Log("Saved");
    }
}

[Serializable]
public class SaveData
{
    public string saveName;
    public Vector3 respawnPosition;
    public List<string> inventoryContents;
    public string currentWeapon;
    public int playerHealth;
    public string level;
    public List<string> enemiesKilled;
    public List<string> weaponsCollected;
    public List<string> doorsOpened;
    public List<string> savePointsCollected = new List<string>();
}
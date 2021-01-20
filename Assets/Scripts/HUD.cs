using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance;
    [Header("In game hud")]
    public Image HealthBar;
    public Image HealthBarBase;
    public InvetoryPresenter Inventory;
    
    [Header("Win and lose screen")]
    public Text YouWin;
    public Text YouLose;
    public Button RestartButton;
    public Button LastCheckpointButton;
    public Button MenuButton;
    public Button QuitButton;

    private bool _onScreenMenuActive;
    private bool _playerActive;

    private void Awake()
    {
        Instance = this;
        Events.OnPlayerDeath += OnPlayerDeath;
        Events.OnPlayerWin += OnPlayerWin;
    }
    private void OnDestroy()
    {
        Events.OnPlayerDeath -= OnPlayerDeath;
        Events.OnPlayerWin -= OnPlayerWin;
    }

    private void Start()
    {
        _playerActive = true;
        ShowOnScreenMenu(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape" ) && _playerActive) 
        {
            _onScreenMenuActive = ShowOnScreenMenu(!_onScreenMenuActive);
        }
    }

    private void OnPlayerWin()
    {
        _playerActive = false;
        YouWin.gameObject.SetActive(true);
        ShowOnScreenMenu(true);
    }

    private void OnPlayerDeath()
    {
        _playerActive = false;
        YouLose.gameObject.SetActive(true);
        ShowOnScreenMenu(true);
    }

    private bool ShowOnScreenMenu(bool show)
    {
        HealthBar.gameObject.SetActive(!show);
        HealthBarBase.gameObject.SetActive(!show);
        Inventory.gameObject.SetActive(!show);
        
        RestartButton.gameObject.SetActive(show);
        LastCheckpointButton.gameObject.SetActive(show);
        MenuButton.gameObject.SetActive(show);
        QuitButton.gameObject.SetActive(show);
        gameObject.GetComponent<Image>().enabled = show;
        
        return show;
    }

    public void OnRestartButtonPressed()
    {
        SaveManager.Instance.RestartLevel();
        Events.Restart();
    }
    
    public void OnLastCheckpointButton()
    {
        Events.LoadCheckpoint();
    }
    
    public void OnMenuButtonPressed()
    {
        MenuPresenter.Instance?.gameObject.SetActive(true);
        SceneManager.LoadScene("MainMenuScene");
    }
    
    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    public void SetHealth(int health)
    {
        HealthBar.fillAmount = (float)health / 100;
        Color color = new Color(255, 0, 0, 255);

        if (HealthBar.fillAmount <= 1)
        {
            color = new Color32(0, 255, 0, 255); // Green
        }
        if (HealthBar.fillAmount < 0.7)
        {
            color = new Color32(255, 255, 0, 255); // Yellow
        }
        if (HealthBar.fillAmount < 0.3)
        {
            color = new Color32(255, 0, 0, 255); // Red
        }
        HealthBar.GetComponent<Image>().color = color;
    }
}

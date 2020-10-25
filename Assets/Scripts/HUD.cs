using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    public static HUD Instance;
    public Image HealthBar;
    public Image HealthBarBase;
    public Text YouWin;
    public Text YouLose;
    public Button RestartButton;

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
    
    private void OnPlayerWin()
    {
        HealthBar.gameObject.SetActive(false);
        HealthBarBase.gameObject.SetActive(false);
        YouWin.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }

    private void OnPlayerDeath()
    {
        HealthBar.gameObject.SetActive(false);
        HealthBarBase.gameObject.SetActive(false);
        YouLose.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }

    public void OnRestartButtonPressed()
    {
        Events.Restart();
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

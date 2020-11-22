using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPresenter : MonoBehaviour
{
    public static MenuPresenter Instance;
    public Button StartButton;
    public Button OptionsButton;
    public Button ExitButton;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        StartButton.onClick.AddListener(StartButtonClicked);
        ExitButton.onClick.AddListener(OnExit);
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public void StartButtonClicked()
    {
        SceneManager.LoadScene("Level 1");
    }
    
    private void OnLevelWasLoaded(int level)
    {
        if (level == 0) return;

        gameObject.SetActive(false);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}

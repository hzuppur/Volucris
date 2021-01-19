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
    public Button ContinueButton;
    public Button OptionsButton;
    public Button ExitButton;
    public Text VolucrisText;

    public OptionsPresenter OptionsPresenter;
    public Button OptionsBackButton;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        StartButton.onClick.AddListener(StartButtonClicked);
        ContinueButton.onClick.AddListener(ContinueButtonClicked);
        ExitButton.onClick.AddListener(OnExit);
        OptionsButton.onClick.AddListener(OnOptionsButtonClicked);
        OptionsBackButton.onClick.AddListener(OnOptionsBackButtonClicked);
        
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    private static void StartButtonClicked()
    {
        SaveManager.Instance.DeleteSaveData();
        LoadLevel();
    }

    private static void ContinueButtonClicked()
    {
        LoadLevel();
    }

    private static void LoadLevel()
    {
        SceneManager.LoadScene(SaveManager.Instance.activeSave.level.Contains("Level")
            ? SaveManager.Instance.activeSave.level
            : "Level 1");
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

    public void OnOptionsButtonClicked()
    {
        OptionsPresenter.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(false);
        OptionsButton.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
        VolucrisText.gameObject.SetActive(false);
    }
    
    public void OnOptionsBackButtonClicked()
    {
        OptionsPresenter.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(true);
        OptionsButton.gameObject.SetActive(true);
        ExitButton.gameObject.SetActive(true);
        VolucrisText.gameObject.SetActive(true);
    }
}

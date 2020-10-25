using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string[] scenes;
    public bool autoLoad = true;

    void Awake()
    {
        Events.OnRestart += OnRestart;
        if (autoLoad)
            LoadScenes();
    }

    private void OnDestroy()
    {
        Events.OnRestart -= OnRestart;
    }

    private void LoadScenes()
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            string name = scenes[i];
            Scene scene = SceneManager.GetSceneByName(name);
            if (!scene.IsValid())
            {
                SceneManager.LoadScene(name, LoadSceneMode.Additive);
            }
        }
    }

    private void OnRestart()
    {
        //StartCoroutine(SceneReload());
        SceneManager.LoadSceneAsync("Level 1", LoadSceneMode.Single);
    }
}
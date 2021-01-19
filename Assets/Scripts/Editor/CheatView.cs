using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CheatView : EditorWindow
{
    [MenuItem("Window/CheatView")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CheatView));
    }
    
    void OnGUI()
    {
        GUILayout.Label ("Weapons", EditorStyles.boldLabel);
        if (GUILayout.Button("Fast blaster"))
        {
            GameAssets.Instance.AddFastBlaster();
        }
        if (GUILayout.Button("Shotgun"))
        {
            GameAssets.Instance.AddShotgun();
        }
        
        GUILayout.Label ("Events", EditorStyles.boldLabel);
        
        if (GUILayout.Button("Restart"))
        {
            Events.Restart();
        }
        if (GUILayout.Button("Win"))
        {
            Events.PlayerWin();
        }
        if (GUILayout.Button("Lose"))
        {
            Events.PlayerDeath();
        }
    }
}

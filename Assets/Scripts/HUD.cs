using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    public static HUD Instance;
    public Image HealthBar;

    private void Awake(){
        Instance = this;
    }

    public void SetHealth(int health){
        HealthBar.fillAmount = (float)health/100;
    }
}

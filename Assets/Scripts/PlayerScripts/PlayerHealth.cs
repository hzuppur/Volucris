using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    private int maxHealth;

    void Start()
    {
        maxHealth = health;
        HUD.Instance.SetHealth(health);
    }

    public void takeDamage(int damageAmount)
    {
        health = Mathf.Clamp(health-damageAmount,0,maxHealth);
        HUD.Instance.SetHealth(health);
        Debug.Log("Player hp = "+health);
        if(health <= 0){Die();}
    }

    public void heal(int healAmount){
        health = Mathf.Clamp(health+healAmount,0,maxHealth);
        HUD.Instance.SetHealth(health);
    }
    void Die(){
        Debug.Log("Player died");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

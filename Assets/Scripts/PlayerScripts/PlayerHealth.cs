using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    public int health = 100;
    private int maxHealth;
    void Start()
    {
        maxHealth = health;
    }

    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Player hp = "+health);
        if(health <= 0){Die();}
    }

    public void heal(int healAmount){
        health += healAmount;
        if(health > maxHealth){health = maxHealth;}
    }
    void Die(){
        Debug.Log("Player died");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

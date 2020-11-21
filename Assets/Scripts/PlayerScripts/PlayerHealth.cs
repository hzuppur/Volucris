using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public AudioClipGroup takeDamageSound;
    public AudioClipGroup dieSound;

    private int maxHealth;

    private void Awake()
    {
        Events.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDestroy()
    {
        Events.OnPlayerDeath -= OnPlayerDeath;
    }

    void Start()
    {
        maxHealth = health;
        HUD.Instance.SetHealth(health);
    }

    public void takeDamage(int damageAmount)
    {
        health = Mathf.Clamp(health-damageAmount,0,maxHealth);
        HUD.Instance.SetHealth(health);
        takeDamageSound.Play();
        
        Debug.Log("Player hp = "+health);
        if(health <= 0){Events.PlayerDeath();}
    }

    public void heal(int healAmount){
        health = Mathf.Clamp(health+healAmount,0,maxHealth);
        HUD.Instance.SetHealth(health);
    }
    void OnPlayerDeath(){
        dieSound.Play();
        gameObject.SetActive(false);
    }

}

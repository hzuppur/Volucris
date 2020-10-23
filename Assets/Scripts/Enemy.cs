using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage){
        health -= damage;
        if(health <=0){Die();}
    }

    void Die(){
        //Instantiate(deathEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}

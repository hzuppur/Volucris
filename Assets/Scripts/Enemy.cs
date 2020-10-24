using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public float Speed;
    public int damageAmount = 50;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Speed, 0, 0);
        transform.position += movement * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyMovementBlocker")
        {
            Speed = Speed * -1;
            transform.Rotate(0, 180, 0);
        }
        
        if(collision.gameObject.tag == "Player"){
            PlayerHealth playerHeatlh = collision.gameObject.GetComponent<PlayerHealth>();
            playerHeatlh.takeDamage(damageAmount);
        }

        
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

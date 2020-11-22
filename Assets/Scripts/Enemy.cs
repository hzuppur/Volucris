using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public float Speed;
    public bool Vertical;
    public bool Follower;
    public float ActivationRange;
    public GameObject Player;
    public int damageAmount = 25;
    public Animator Animator;

    private static readonly int aniSpeed = Animator.StringToHash("aniSpeed");
    private Vector3 startPos;
    private bool goingBackToStart = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - startPos.x) < 1)
        {
            goingBackToStart = false;
        }

        Vector3 movement;

        if (Follower)
        {
            float point;
            if (goingBackToStart)
            {
                point = startPos.x;
            }
            else
            {
                point = Player.gameObject.transform.position.x;
            }
       
            if (Mathf.Abs(transform.position.x - point) <= ActivationRange && Mathf.Abs(transform.position.x - point) > 0.1 || goingBackToStart)
            {
                if (transform.position.x - point > 0 && Speed > 0)
                {
                    rotate();
                }

                else if (transform.position.x - point < 0 && Speed < 0)
                {
                    rotate();
                }

                movement = new Vector3(Speed, 0, 0);
            }
            else
            {
                movement = new Vector3(0, 0, 0);
            }
        }
        else
        {
            if (Vertical)
            {
                movement = new Vector3(0, Speed, 0);
            }

            else
            {
                movement = new Vector3(Speed, 0, 0);
            }

        }

        Animator.SetFloat(aniSpeed, Mathf.Abs(movement.x));
        transform.position += movement * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyMovementBlocker")
        {
            rotate();
            if (Follower)
            {
                goingBackToStart = true;
            }
        }
        
        if(collision.gameObject.tag == "Player"){
            PlayerHealth playerHeatlh = collision.gameObject.GetComponent<PlayerHealth>();
            playerHeatlh.takeDamage(damageAmount);
        }
    }

    private void rotate()
    {
        Speed = Speed * -1;
        if (!Vertical)
        {
            transform.Rotate(0, 180, 0);
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

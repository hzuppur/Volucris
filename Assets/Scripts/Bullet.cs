using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 100;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public Color bulletColor;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        if (bulletColor != Color.white)
        {
            gameObject.GetComponent<SpriteRenderer>().color = bulletColor;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null){
            enemy.TakeDamage(damage);
        }
        Instantiate(impactEffect,transform.position,transform.rotation);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

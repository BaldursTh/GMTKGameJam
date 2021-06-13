using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWall : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float knockback;
    Rigidbody2D rb;
    public Sprite wall1;
    public Sprite wall2;
    public GameObject Top;


    private void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Bullet"))
        {
            TakeDamage();
            rb.AddForce((collider.transform.GetComponent<Rigidbody2D>().velocity) * knockback);
            Destroy(collider.gameObject);
        }
        if (collider.CompareTag("EnemyBullet"))
        {
            TakeDamage();
            rb.AddForce((collider.transform.GetComponent<Rigidbody2D>().velocity) * knockback);
            Destroy(collider.gameObject);
        }

    }
    public void TakeDamage()
    {
        health -= 1;
        
        if (health == 2)
        {
            Top.GetComponent<SpriteRenderer>().sprite = wall1;

            GetComponent<SpriteRenderer>().sprite = wall1;
        }
        else if (health == 1)
        {
            Top.GetComponent<SpriteRenderer>().sprite = wall2;
            GetComponent<SpriteRenderer>().sprite = wall2;

        }
        else if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

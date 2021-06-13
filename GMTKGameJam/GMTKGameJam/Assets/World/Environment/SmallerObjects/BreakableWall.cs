using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float knockback;
    Rigidbody2D rb;

    private void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Bullet"))
        {
            Destroy(collider);
            Destroy(gameObject);
           
        }
        if (collider.CompareTag("EnemyBullet"))
        {
            Destroy(collider);
            Destroy(gameObject);
        }


    }
}

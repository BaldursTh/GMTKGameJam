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
            health -= 1;
            rb.AddForce((collider.transform.GetComponent<Rigidbody2D>().velocity) * knockback);
            Destroy(collider.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }  


    }
}

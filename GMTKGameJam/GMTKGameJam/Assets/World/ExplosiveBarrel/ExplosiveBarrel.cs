using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public float explosionRadius;
    public float forceNeededToExplode;
    

    public float explosionForce;
    public List<Rigidbody2D> objectRb;
    LayerMask layerMask;
    
    public Collider2D[] objects;
    public void Start()
    {

        layerMask = LayerMask.GetMask("Enemy", "Player", "MovingObjects");
    }
    

    void Explode()
    {
        objects = Physics2D.OverlapCircleAll(transform.position, explosionRadius, layerMask);
        if (objectRb != null)
        {
            objectRb.Clear();
        }

        foreach (Collider2D collider in objects)
        {
            objectRb.Add(collider.transform.GetComponent<Rigidbody2D>());
            Vector2 direction = transform.GetDirection(collider.transform.position);
            Rigidbody2D rb = collider.transform.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * explosionForce);
            if (collider.gameObject.layer == 9)
            {
                Destroy(collider.gameObject);
            }
        }
        Destroy(gameObject);



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Bullet"))
        {

            Explode();
        }
    }
    float impact;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        impact = collision.relativeVelocity.sqrMagnitude;

        if (impact > forceNeededToExplode)
        {
            Explode();
        }
    }
}

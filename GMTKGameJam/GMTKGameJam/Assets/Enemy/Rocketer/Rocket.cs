using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float explosionRadius;
    public float forceNeededToExplode;


    public float explosionForce;
    public List<Rigidbody2D> objectRb;
    LayerMask layerMask;

    public Collider2D[] objects;
    public void Awake()
    {
        camShake = Camera.main.GetComponent<CameraShake>();
        layerMask = LayerMask.GetMask("Enemy", "Player", "MovingObjects");
    }

    public CameraShake camShake;
    public float camShakemag;
    public float camShakeDur;
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
            
        }

        



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Objects"))
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    float impact;
    public GameObject explosionEffect;
    private void OnDestroy()
    {
        camShake.Shake(camShakeDur, camShakemag);
        Explode();
        
    }

}

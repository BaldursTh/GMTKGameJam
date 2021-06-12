using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Blackhole : MonoBehaviour
{
    public float blackHoleRadius;
    public float suctionForce;
    public List<Rigidbody2D> objectRb;
    LayerMask layerMask;
    public Collider2D[] objects;
    public void Start()
    {
        InvokeRepeating("AddForceToEverything", 0, 0.5f);
        layerMask = LayerMask.GetMask("Enemy", "Player", "MovingBackground");
    }
    public void FixedUpdate()
    {
        
    }

    void AddForceToEverything()
    {
        objects = Physics2D.OverlapCircleAll(transform.position, blackHoleRadius, layerMask);
        if (objectRb != null)
        {
            objectRb.Clear();
        }
        
        foreach (Collider2D collider in objects)
        {
            objectRb.Add(collider.transform.GetComponent<Rigidbody2D>());
            Vector2 direction = transform.GetDirection(collider.transform.position);
            Rigidbody2D rb = collider.transform.GetComponent<Rigidbody2D>();
            rb.AddForce(-(direction * suctionForce));
        }
        


    }
}

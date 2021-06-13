using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Blackhole : MonoBehaviour
{
    public float blackHoleRadius;
    public float blackHoleRadiusGrowth;
    public float suctionRadiusGrowth;

    public CameraScript Camera;
    public float suctionForce;
    public List<Rigidbody2D> objectRb;
    LayerMask layerMask;
    public Collider2D[] objects;
    public void Start()
    {
        InvokeRepeating("AddForceToEverything", 0, 0.5f);
        layerMask = LayerMask.GetMask("Enemy", "Player", "MovingObjects");
    }
    public void FixedUpdate()
    {
        blackHoleRadius += suctionRadiusGrowth;
        

        transform.localScale = new Vector2(transform.localScale.x + blackHoleRadiusGrowth, transform.localScale.y + blackHoleRadiusGrowth);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
     
     Gizmos.DrawWireSphere(transform.position, blackHoleRadius);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Camera.Kill();
        }
        Destroy(collision.gameObject);
    }
}

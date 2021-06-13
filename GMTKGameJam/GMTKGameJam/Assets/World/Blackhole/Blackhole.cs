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

    public GameObject camera;
    public CameraScript cameraScript;

    #region MonoBehaviour callbacks
    public void Start()
    {
        InvokeRepeating("AddForceToEverything", 0, 0.5f);
        layerMask = LayerMask.GetMask("Enemy", "Player", "MovingObjects");
    }
    public void FixedUpdate()
    {
        
    }
    #endregion

    #region Methods
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
<<<<<<< Updated upstream
=======

    #endregion
    #region Collision Detection
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            cameraScript.SetDead();
        }
        Destroy(collision.gameObject);
    }
    #endregion
>>>>>>> Stashed changes
}

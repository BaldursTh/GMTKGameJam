using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public Rigidbody2D grappleRB;
    public Rigidbody2D characterRB;
    public GameObject grapple;
    public bool isGrappling = false;
    private bool isPulling = false;
    private bool isRetracting = false;
    private Vector3 pullLoc;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        CheckIfHolding();
        if (Input.GetMouseButton(1))
        {
            if (!isGrappling)
            {
                ShootGrapple();
            }
        }
        else
        {
            RetractGrapple();
        }
    }

    void CheckIfHolding()
    {
        if (Vector3.Distance(transform.position, grapple.transform.position) < 1)
        {

            FreezeGrapple();
            gameObject.SetActive(true);
            isGrappling = false;
            isRetracting = false;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            FreezeCharacter();
            isPulling = false;
        }
    }

    void ShootGrapple()
    {
        gameObject.SetActive(true);
        isGrappling = true;
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;
        grappleRB.AddForce(mouseDir * 40);
    }

    void FreezeGrapple()
    {
        grappleRB.velocity = Vector3.zero;
    }
    void FreezeCharacter()
    {
        characterRB.velocity = Vector3.zero;
    }

    void RetractGrapple()
    {
        FreezeGrapple();
        grappleRB.AddForce((transform.position - grapple.transform.position) * 20);

    }

    public void PullPlayer(Vector3 Location)
    {
        FreezeGrapple();
        characterRB.AddForce((Location - grapple.transform.position) * 500);
        pullLoc = Location;
    }
}

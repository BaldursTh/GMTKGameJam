using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleCollision : MonoBehaviour
{
    public GameObject player;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            player.GetComponent<Grapple>().PullPlayer(collision.transform.position);
            print("pulling");
        }
    }
}

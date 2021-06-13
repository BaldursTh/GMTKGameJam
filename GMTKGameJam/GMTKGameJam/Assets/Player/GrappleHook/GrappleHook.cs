using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    public float grappleForce;
    Vector2 direction;
    public GameObject line;
    float angle;

    private void Update()
    {
        direction = (player.transform.position - transform.position);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector2 midPoint = (player.transform.position + transform.position) / 2;
        line.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        line.transform.localScale = new Vector2(Vector3.Distance(player.transform.position, transform.position), line.transform.localScale.y);
        line.transform.position = midPoint;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Objects"))
        {
            direction = (player.transform.position - transform.position).normalized;

            rb = player.transform.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.AddForce(direction * -grappleForce);
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemies"))
        {
            direction = (player.transform.position - transform.position).normalized;

            rb = player.transform.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.AddForce(direction * -grappleForce);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
public class RangedEnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player;
    public float distanceFromPlayer;
    public float moveSpeed;
    public float moveSpeedWhenReloading;
    public float rangeGap;
    public float reloadTime;
    public GameObject arrow;
    public Vector2 direction;
    public float pullTime;
    public bool isShooting;
    public float arrowTravelSpeed;
    float impact;
    public float forceNeededToDie;
    public GameObject shootPos;

    float blockDetectionRange;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isShooting = false;
        anim = GetComponent<Animator>();
    }

    RaycastHit2D hit;
    void Update()
    {
        direction = (transform.position - player.transform.position);
        hit = Physics2D.Raycast(transform.position, direction, blockDetectionRange);
        Animations();
        if (hit)
        {
            if (hit.transform.CompareTag("Objects"))
            {
                RangedAttack();
            }
        }


        if (direction.magnitude < distanceFromPlayer && isShooting == false)
        {
            if (!player.GetComponent<PlayerScript>().anim.isStunned)
            {
                StartCoroutine(RangedAttack());
            }
           



        }
        else if (isShooting == false && direction.magnitude <= distanceFromPlayer)
        {
            rb.velocity = direction.normalized * moveSpeed;
        }
        else if (isShooting == false && direction.magnitude >= distanceFromPlayer)
        {
            rb.velocity = -direction.normalized * moveSpeed;
        }
    }
    IEnumerator RangedAttack()
    {
        isShooting = true;
        anim.SetTrigger("Shoot");
        rb.velocity = Vector2.zero;
        

        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject arrowClone = Instantiate(arrow, shootPos.transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
        arrowClone.GetComponent<Rigidbody2D>().velocity = direction.normalized * -arrowTravelSpeed;
        yield return new WaitForSeconds(reloadTime);
        anim.ResetTrigger("Shoot");
        Destroy(arrowClone, 5f);
        isShooting = false;
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        impact = collision.relativeVelocity.sqrMagnitude;

        if (impact > forceNeededToDie)
        {
            Destroy(gameObject); 
        }
    }

    public Animator anim;
    float angle;
    float checkAngle;
    public void Animations()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        angle  = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle > 135) { checkAngle = -(360 - angle); }
        else if (angle < -135) { checkAngle = (360 + angle); }
        else { checkAngle = -1111; }
        anim.SetFloat("Angle", angle);
        anim.SetFloat("CheckAngle", checkAngle);
    }
    public GameObject explosionEffect;
    private void OnDestroy()
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        explosion.transform.localScale = explosion.transform.localScale / 2;
    }

}

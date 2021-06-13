using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Start is called before the first frame update+
    [SerializeField] GameObject target;
    [Range(5f, 30f)] public float speed = 15;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    private bool canShoot = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot ()
    {
        if(canShoot)
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(transform.position, target.transform.position - transform.position);
            Debug.DrawRay(transform.position, target.transform.position - transform.position);
            if (hit.collider.name == "Character")
            {
                GameObject _bulletObj = Instantiate(bullet, shootPoint.position, Quaternion.identity);
                _bulletObj.GetComponent<Rigidbody2D>().AddForce(speed * (target.transform.position - transform.position));
            }
            StartCoroutine(Cooldown());
        }
    }
        

    IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}


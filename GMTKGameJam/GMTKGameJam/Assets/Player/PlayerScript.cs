using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Player 
{
    public class PlayerScript : MonoBehaviour
    {
        #region MonobehaviourCallbacks
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            canShoot = true;
            leftPivot = GameObject.FindGameObjectWithTag("LeftGun");
            rightPivot = GameObject.FindGameObjectWithTag("RightGun");
            downPivot = GameObject.FindGameObjectWithTag("ForwardGun");
            gunAnimators[0] = leftPivot.GetComponent<Animator>();
            gunAnimators[1] = rightPivot.GetComponent<Animator>();
            gunAnimators[2] = downPivot.GetComponent<Animator>();
            anim = graphics.GetComponent<Animations>();

        }
        void Update()
        {
            HandleInput();
            
        }
        


        #endregion

        #region Variables
        public GameObject bulletPrefab;
        public PlayerData data;
        Rigidbody2D rb;
        bool canShoot;
        bool canGrapple = true;
        GameObject leftPivot;
        GameObject rightPivot;
        GameObject downPivot;
        Animator[] gunAnimators = new Animator[3];
        public GameObject grapplePrefab;


        #endregion

        #region Parameters
        public float playerKnockbackForce => data.playerKnockbackForce;
        public float bulletSpeed => data.bulletSpeed;
        public float shootCooldown => data.shootCooldown;
        public float speedCap => data.speedCap;
        public float grappleSpeed => data.grappleSpeed;
        public float grappleDistance => data.grappleDistance;
        #endregion

        #region Methods
        void HandleInput()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                CheckShoot();
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                GrappleHook();
            }
        }

        #endregion
        #region GrappleHook 
        void GrappleHook()
        {
            if (canGrapple)
            {
                Vector2 dir = transform.GetMouseDirection();
                GameObject _grapplePrefab = Instantiate(grapplePrefab, transform.position, Quaternion.identity);
                _grapplePrefab.GetComponent<Rigidbody2D>().velocity = dir * grappleSpeed;
                _grapplePrefab.GetComponent<GrappleHook>().player = this.gameObject;
                StartCoroutine(GrappleCooldown());
                Destroy(_grapplePrefab, grappleDistance);
            }


        }
        IEnumerator GrappleCooldown()
        {
            canGrapple = false;
            yield return new WaitForSeconds(shootCooldown);
            canGrapple = true;
        }
        
        #endregion

        #region Shooting
        void CheckShoot()
        {

            if (canShoot)
            {
                Shoot();
            }
        }
        void Shoot()
        {
            StartCoroutine(ShootCooldown());
            Vector2 direction = transform.GetMouseDirection();
            float angle = transform.GetMouseAngle();
            
            GameObject _bulletPrefab = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 1), Quaternion.AngleAxis(angle+180, Vector3.forward));
            _bulletPrefab.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed);
            
                rb.AddForce(-(direction * playerKnockbackForce));
            if (rb.velocity.magnitude > speedCap)
            {
                rb.velocity = rb.velocity.normalized * speedCap;
            }
            Destroy(_bulletPrefab, 10);

        }

        IEnumerator ShootCooldown()
        {
            foreach (Animator anim in gunAnimators)
            {
                anim.SetBool("isShooting", true);

            }
            canShoot = false;
            yield return new WaitForSeconds(shootCooldown);
            canShoot = true;
            foreach (Animator anim in gunAnimators)
            {
                anim.SetBool("isShooting", false);
            }
        }


        #endregion

        public float StunDuration;
        public float StunIncrease;
        public GameObject graphics;
        public Animations anim;
        #region CollisionDetection
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("EnemyBullet"))
            {
                if (!anim.isStunned)
                {
                    Stun();
                    Destroy(collision.gameObject);
                }
                

            }
        }
        public void Stun()
        {
            StartCoroutine(Stunned());
        }
        IEnumerator Stunned()
        {
           
            anim.isStunned = true;
            canShoot = false;
            canGrapple = false;
            for (float i = 0; i < StunDuration; i += StunIncrease*Time.deltaTime)
            {
                if (anim.angle > 180)
                {
                    anim.angle = -180;
                }
                canGrapple = false;
                canShoot = false;
                anim.angle += StunIncrease * Time.deltaTime;
                
                yield return null;
            }
            canGrapple = true;
            canShoot = true;
            anim.isStunned = false; 
        }
        #endregion

    }
}

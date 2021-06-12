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
        GameObject leftPivot;
        GameObject rightPivot;
        GameObject downPivot;
        Animator[] gunAnimators = new Animator[3];


        #endregion

        #region Parameters
        public float playerKnockbackForce => data.playerKnockbackForce;
        public float bulletSpeed => data.bulletSpeed;
        public float shootCooldown => data.shootCooldown;
        public float speedCap => data.speedCap;
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

        #region CollisionDetection
        

        #endregion

    }
}

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


        #endregion

        #region Parameters
        public float playerKnockbackForce => data.playerKnockbackForce;
        public float bulletSpeed => data.bulletSpeed;
        public float shootCooldown => data.shootCooldown;
        #endregion

        #region Methods
    void HandleInput()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                CheckShoot();
            }
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
            print(direction);
            GameObject _bulletPrefab = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            _bulletPrefab.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed);
            rb.AddForce(-(direction * playerKnockbackForce));

        }

        IEnumerator ShootCooldown()
        {
            canShoot = false;
            yield return new WaitForSeconds(shootCooldown);
            canShoot = true;
        }


        #endregion



    }
}

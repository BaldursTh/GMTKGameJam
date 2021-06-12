using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyShoot : MonoBehaviour
    {
        public EnemyData enemyData;
        public GameObject player;
        public Transform playerTransform;


        [SerializeField] protected GameObject enemyBullet;
        [SerializeField] protected Transform shootPoint;

        [Range(25f, 75f)]
        public float bulletSpeed;

        protected bool canShoot = true;
        void Update()
        {
            ShootCheck();
        }
        void Shoot()
        {
            StartCoroutine(Cooldown());
            Vector2 toVector = playerTransform.position - transform.position;
            float angle = Vector2.Angle(transform.up, toVector);

            GameObject _bulletPrefab = Instantiate(enemyBullet, new Vector3(transform.position.x, transform.position.y, 1), Quaternion.AngleAxis(angle + 180, Vector3.forward));
            _bulletPrefab.GetComponent<Rigidbody2D>().AddForce(toVector * bulletSpeed);

            Destroy(_bulletPrefab, 10);
        }
        void ShootCheck()
        {
            if (CheckForLineOfSight())
            {
                

                if (canShoot)
                {
                    StartCoroutine(Cooldown());
                    print("spawning bullet");
                    GameObject _bulletObj = Instantiate(enemyBullet, shootPoint.position, Quaternion.identity);
                    _bulletObj.GetComponent<Rigidbody2D>().AddForce(enemyData.bulletSpeed * (player.transform.position - transform.position));
                }


            }
        }

        bool CheckForLineOfSight()
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, Mathf.Infinity);
            Debug.DrawRay(transform.position, player.transform.position - transform.position);
            if (hit.collider.gameObject.layer == 6) return true;
            return false;
        }

        IEnumerator Cooldown()
        {
            canShoot = false;
            yield return new WaitForSeconds(enemyData.cooldown);
            canShoot = true;
        }


    }

}
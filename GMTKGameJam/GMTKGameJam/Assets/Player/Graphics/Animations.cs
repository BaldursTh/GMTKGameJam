using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
namespace Player
{
    public class Animations : MonoBehaviour
    {
        
        public float angle;
        public float checkAngle;
        public Animator animator;
        GameObject leftPivot;
        GameObject rightPivot;
        GameObject downPivot;
        public bool isStunned;
        private void Awake()
        {
            leftPivot = GameObject.FindGameObjectWithTag("LeftGun");
            rightPivot = GameObject.FindGameObjectWithTag("RightGun");
            downPivot = GameObject.FindGameObjectWithTag("ForwardGun");
        }
        private void Update()
        {
            if (!isStunned)
            {
                Animation();
            }
            if (angle > 135) { checkAngle = -(360 - angle); }
            else if (angle < -135) { checkAngle = (360 - angle); }
            else { checkAngle = -1111; }
            animator.SetFloat("PlayerAngle", angle);
            animator.SetFloat("PlayerAngleCheck", checkAngle);

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRight"))
            {
                rightPivot.SetActive(true);
                leftPivot.SetActive(false);
                downPivot.SetActive(false);
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerLeft"))
            {
                leftPivot.SetActive(true);
                rightPivot.SetActive(false);
                downPivot.SetActive(false);
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerDown"))
            {
                downPivot.SetActive(true);
                rightPivot.SetActive(false);
                leftPivot.SetActive(false);
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerUp"))
            {
                rightPivot.SetActive(false);
                leftPivot.SetActive(false);
                downPivot.SetActive(false);
            }

        }
        public void Animation()
        {
            angle = transform.GetMouseAngle();
            
           
        }
    }
}

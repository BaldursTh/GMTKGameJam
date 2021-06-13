using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Game Data/Player Data")]
    public class PlayerData : ScriptableObject
    {
        public float playerKnockbackForce;
        public float bulletSpeed;
        public float bulletDamage;
        public float shootCooldown;
        public float speedCap;
        public float grappleSpeed;
        public float grappleDistance;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Game Data/Enemy Data", order = 1)]
    public class EnemyData : ScriptableObject
    {
        public float cooldown;
        public float speed;
        public float health;
    }

}

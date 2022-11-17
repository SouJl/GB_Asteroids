using UnityEngine;

namespace GB_Asteroids
{
    [CreateAssetMenu(fileName = "AsteroidEnemyConfig", menuName = "ScriptableObjects/EnemyConfigs/AsteroidEnemyConfig")]
    public class AsteroidEnemyConfig: EnemyConfig
    {
        [Header("Asteroid Settings")]

        public float MinSize;
        public float MaxSize;
    }
}

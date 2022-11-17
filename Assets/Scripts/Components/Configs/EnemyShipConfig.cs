using UnityEngine;

namespace GB_Asteroids
{
    [CreateAssetMenu(fileName = "EnemyShipConfig", menuName = "ScriptableObjects/EnemyConfigs/EnemyShipConfig")]
    public class EnemyShipConfig: EnemyConfig
    {
        public float FireRate;
    }
}

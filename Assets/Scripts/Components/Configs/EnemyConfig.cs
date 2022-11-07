using UnityEngine;

namespace GB_Asteroids
{ 
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyConfigs/EnemyConfig")]
    public class EnemyConfig: ScriptableObject
    {
        [Header("Base Enemy Settings")]

        public string Name;
        public EnemyType Type;

        public float MaxHealth;
        public float Damage;
        public float Points;

        public GameObject Prefab;
    }
}

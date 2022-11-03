using UnityEngine;

namespace GB_Asteroids
{ 
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyScriptableObject")]
    public class EnemyConfig: ScriptableObject
    {
        public string Name;
        public EnemyType Type;

        public float MinSize;
        public float MaxSize;

        public float MaxHealth;
        public float Damage;
        public float Points;

        public GameObject Prefab;
    }
}

using UnityEngine;

namespace GB_Asteroids
{
    public abstract class EnemyFactory : ScriptableObject, IEnemyFactory
    {
        [SerializeField] private EnemyConfig _config;
        public EnemyConfig Config { get => _config; set => _config = value; }

        public abstract IEnemy Create(Vector3 position, Quaternion rotation);
    }
}


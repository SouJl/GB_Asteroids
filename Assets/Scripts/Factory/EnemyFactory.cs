using GB_Asteroids.Enemy;
using UnityEngine;

namespace GB_Asteroids
{
    public abstract class EnemyFactory : ScriptableObject, IEnemyFactory
    {
        public abstract IEnemy Create(EnemyType type, Vector3 position, Quaternion rotation);
    }
}


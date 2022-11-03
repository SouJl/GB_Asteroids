using UnityEngine;

namespace GB_Asteroids
{
    public abstract class EnemyFactory : ScriptableObject, IEnemyFactory
    {
        public abstract IEnemy Create(EnemyType type, Vector3 position, Quaternion rotation);

        public abstract EnemyView CreateView(EnemyType type, Vector3 position, Quaternion rotation);
    }
}


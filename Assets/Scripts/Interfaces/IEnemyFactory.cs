using UnityEngine;

namespace GB_Asteroids
{
    public interface IEnemyFactory
    {
        IEnemy Create(EnemyType type, Vector3 position, Quaternion rotation);
    }
}

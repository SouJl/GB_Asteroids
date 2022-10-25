using UnityEngine;

namespace GB_Asteroids
{
    public interface IEnemyFactory
    {
        EnemyConfig Config { get; set; }

        IEnemy Create(Vector3 position, Quaternion rotation);
    }
}

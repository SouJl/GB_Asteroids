using GB_Asteroids.Enemy;
using UnityEngine;

namespace GB_Asteroids
{
    public interface IEnemyFactory
    {
        IEnemy Create(EnemyType type, Vector3 position, Quaternion rotation);

        AsteroidModel CreateAsteroid(Vector3 position, Quaternion rotation);

        EnemyShipModel CreateShip(Vector3 position, Quaternion rotation);
    }
}

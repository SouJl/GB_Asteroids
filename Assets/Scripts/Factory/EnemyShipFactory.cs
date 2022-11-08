using GB_Asteroids.Enemy;
using UnityEngine;

namespace GB_Asteroids
{
    public class EnemyShipFactory:IEnemyFactory
    {
        private EnemyConfig _enemyShip;

        public EnemyShipFactory(EnemyConfig enemyConfig) 
        {
            _enemyShip = enemyConfig;
        }

        public IEnemy Create(EnemyType type, Vector3 position, Quaternion rotation)
        {
            var obj = Object.Instantiate(_enemyShip.Prefab, position, rotation);
            return new EnemyShipModel(_enemyShip, obj.GetComponent<EnemyView>());
        }

    }
}

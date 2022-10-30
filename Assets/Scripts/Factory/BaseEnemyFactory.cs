using GB_Asteroids.Enemy;
using System;
using UnityEngine;

namespace GB_Asteroids
{
    [CreateAssetMenu(fileName = "BaseEnemyFactory", menuName = "ScriptableObjects/BaseEnemyFactory")]
    public class BaseEnemyFactory : EnemyFactory
    {
        [SerializeField] private EnemyConfig _asteroid;

        [SerializeField] private EnemyConfig _enemyShip;



        public override IEnemy Create(EnemyType type, Vector3 position, Quaternion rotation)
        {
            switch (type) 
            {
                case EnemyType.Asteroid: 
                    {
                        var obj = Instantiate(_asteroid.Prefab, position, rotation);
                        return new AsteroidModel(_asteroid, obj.GetComponent<EnemyView>());
                    }
                case EnemyType.EnemyShip:
                    {
                        var obj = Instantiate(_enemyShip.Prefab, position, rotation);
                        return new EnemyShipModel(_enemyShip, obj.GetComponent<EnemyView>());
                    }
                default:
                    return null;

            }
        }
    }
}

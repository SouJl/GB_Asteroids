using GB_Asteroids.Enemy;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    [CreateAssetMenu(fileName = "BaseEnemyFactory", menuName = "ScriptableObjects/EnemyFactory/BaseEnemyFactory")]
    public class BaseEnemyFactory : EnemyFactory
    {
        [SerializeField] private AsteroidEnemyConfig _asteroid;

        [SerializeField] private EnemyConfig _enemyShip;


        public override IEnemy Create(EnemyType type, Vector3 position, Quaternion rotation)
        {
            switch (type) 
            {
                case EnemyType.Asteroid: 
                    {
                        return CreateAsteroid(position, rotation);
                    }
                case EnemyType.EnemyShip:
                    {
                        return CreateShip(position, rotation);
                    }
                default:
                    return null;

            }
        }

        public AsteroidModel CreateAsteroid(Vector3 position, Quaternion rotation)
        {
            var obj = Instantiate(_asteroid.Prefab, position, rotation);
            
            BoundsCheck bounds = obj.AddComponent<BoundsCheck>();
            bounds.KeepOnScreen = false;

            AsteroidView view = obj.AddComponent<AsteroidView>();

            view.MaxHealth = _asteroid.MaxHealth;
            view.Damage = _asteroid.Damage;
            view.Points = _asteroid.Points;
            view.MinSize = _asteroid.MinSize;
            view.Size = UnityEngine.Random.Range(_asteroid.MinSize, _asteroid.MaxSize);

            return new AsteroidModel(view);
        }

        public EnemyShipModel CreateShip(Vector3 position, Quaternion rotation)
        {
            var obj = Instantiate(_enemyShip.Prefab, position, rotation);
            return new EnemyShipModel(_enemyShip, obj.GetComponent<EnemyView>());
        }
    }
}

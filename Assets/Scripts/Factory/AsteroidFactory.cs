using GB_Asteroids.Enemy;
using System;
using UnityEngine;

namespace GB_Asteroids
{
    public class AsteroidFactory : IEnemyFactory
    {
        private AsteroidEnemyConfig _asteroid;

        public AsteroidFactory(AsteroidEnemyConfig enemyConfig) 
        {
            _asteroid = enemyConfig;
        }

        public IEnemy Create(EnemyType type, Vector3 position, Quaternion rotation)
        {

            var obj = UnityEngine.Object.Instantiate(_asteroid.Prefab, position, rotation);

            BoundsCheck bounds = obj.AddComponent<BoundsCheck>();
            bounds.KeepOnScreen = false;

            AsteroidView view = obj.AddComponent<AsteroidView>();
            
            view.Type = type;
            view.MaxHealth = _asteroid.MaxHealth;
            view.Damage = _asteroid.Damage;
            view.Points = _asteroid.Points;
            view.MinSize = _asteroid.MinSize;
            view.Size = UnityEngine.Random.Range(_asteroid.MinSize, _asteroid.MaxSize);

            return new AsteroidModel(view);
        }

    }
}

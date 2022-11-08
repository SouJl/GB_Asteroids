using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    [CreateAssetMenu(fileName = "CompositeEnemyFactory", menuName = "ScriptableObjects/EnemyFactory/CompositeEnemyFactory")]
    public class CompositeEnemyFactory : EnemyFactory
    {
        [SerializeField] private AsteroidEnemyConfig _asteroid;

        [SerializeField] private EnemyConfig _enemyShip;

        Dictionary<EnemyType, IEnemyFactory> _factories = new Dictionary<EnemyType, IEnemyFactory>();

        public void AddFactory(EnemyType type) 
        {
            switch (type) 
            {
                case EnemyType.Asteroid: 
                    {
                        _factories.Add(type, new AsteroidFactory(_asteroid));
                        break;
                    }
                case EnemyType.EnemyShip:
                    {
                        _factories.Add(type, new EnemyShipFactory(_asteroid));
                        break;
                    }
            }          
        }

        public override IEnemy Create(EnemyType type, Vector3 position, Quaternion rotation)
        {
            return _factories[type].Create(type, position, rotation);
        }
    }
}

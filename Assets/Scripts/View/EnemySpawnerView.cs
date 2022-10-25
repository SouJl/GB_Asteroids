using UnityEngine;

namespace GB_Asteroids
{
    public class EnemySpawnerView: BaseView
    {
        [SerializeField] private EnemyFactory _enemyFactory;

        [SerializeField] private AsteroidSpawnView _asteroidsSpawner;
        [SerializeField] private EnemyShipSpawnView _enemyShipSpawner;
        
        public EnemyFactory EnemyFactory { get => _enemyFactory;}
        public AsteroidSpawnView AsteroidsSpawner { get => _asteroidsSpawner;}
        public EnemyShipSpawnView EnemyShipSpawner { get => _enemyShipSpawner;}

        protected override void Awake()
        {
            base.Awake();
        }
    }
}

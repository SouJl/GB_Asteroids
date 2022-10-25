using UnityEngine;

namespace GB_Asteroids
{
    public class EnemySpawnerView: BaseView
    {
        [SerializeField] private EnemyFactory _enemyFactory;

        [SerializeField] private AsteroidSpawnView _asteroidsSpawner;

        public EnemyFactory EnemyFactory { get => _enemyFactory; set => _enemyFactory = value; }
        public AsteroidSpawnView AsteroidsSpawner { get => _asteroidsSpawner; set => _asteroidsSpawner = value; }

        protected override void Awake()
        {
            base.Awake();
        }
    }
}

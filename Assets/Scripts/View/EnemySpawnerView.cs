using UnityEngine;

namespace GB_Asteroids
{
    public class EnemySpawnerView: BaseView
    {
        [SerializeField] private AsteroidSpawnView _asteroidsSpawner;

        public AsteroidSpawnView AsteroidsSpawner { get => _asteroidsSpawner; set => _asteroidsSpawner = value; }

        protected override void Awake()
        {
            base.Awake();
        }
    }
}

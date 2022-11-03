using GB_Asteroids.Enemy;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GB_Asteroids
{
    public class AsteroidSpawnerModel: ISpawner
    {
        private float _spawnDistance;
        private float _spawnRate;
        private int _amountPerSpawn;
        private float _trajectoryVariance;
        private IEnemyFactory _factory;

        public float SpawnDistance { get => _spawnDistance; private set => _spawnDistance = value; }
        public float SpawnRate { get => _spawnRate; private set => _spawnRate = value; }
        public int AmountPerSpawn { get => _amountPerSpawn; private set => _amountPerSpawn = value; }
        public float TrajectoryVariance { get => _trajectoryVariance; private set => _trajectoryVariance = value; }
        
        public float TimeBeforeSpawn { get; set; }

        private Transform _rootTransform;

        private List<AbstractEnemy> asteroids; 

        public AsteroidSpawnerModel(IEnemyFactory factory, AsteroidSpawnView spawnView, Transform rootTransform) 
        {
            _factory = factory;

            SpawnDistance = spawnView.SpawnDistance;           
            SpawnRate = spawnView.SpawnRate;
            AmountPerSpawn = spawnView.AmountPerSpawn;
            TrajectoryVariance = spawnView.TrajectoryVariance;

            _rootTransform = rootTransform;

            TimeBeforeSpawn = SpawnRate;

            asteroids = new List<AbstractEnemy>();
        }

        public void Spawn()
        {
            if (TimeBeforeSpawn < SpawnRate) return;

            for (int i = 0; i < AmountPerSpawn; i++)
            {
                var postion = GetPosition();
                var rotation = GetRotation();

                // var asteroid = _factory.Create(EnemyType.Asteroid, postion, rotation).Clone();

                var asteroid = _factory.CreateView(EnemyType.Asteroid, postion, rotation);
                AsteroidModel asteroidModel = new AsteroidModel(asteroid as AsteroidView);
                
                asteroidModel.Health.EndOfHpAction += Split;
                asteroidModel.Health.EndOfHpAction += asteroid.Defeat;
                asteroidModel.Transform = asteroid.Transform;
                asteroidModel.Rigidbody = asteroid.RigidBody;
                asteroid.Interact += asteroidModel.Interaction;

                asteroidModel.SetTrajectory(rotation * -postion);

                asteroids.Add(asteroidModel);
            }

            TimeBeforeSpawn = 0;
        }

        public Vector3 GetPosition()
        {
            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPoint = spawnDirection * SpawnDistance;
            spawnPoint += _rootTransform.position;
            
            return spawnPoint;
        }

        public Quaternion GetRotation()
        {
            float variance = Random.Range(-TrajectoryVariance, TrajectoryVariance);
            return Quaternion.AngleAxis(variance, Vector3.forward);
        }

        private void Split(bool state)
        {
            var asteroid = asteroids.Where(a => a.Health.CurrentHealth == 0).First();
            
            CreateSplit(asteroid);
            CreateSplit(asteroid);

            asteroids.Remove(asteroid);
        }

        private void CreateSplit(AbstractEnemy asteroid)
        {
            Vector2 position = asteroid.Transform.position;
            position += Random.insideUnitCircle * 0.5f;

            var halfAsteroidView = _factory.CreateView(EnemyType.Asteroid, position, Quaternion.identity);

            asteroid.MaxHealth *= 0.5f;
            
            var halfAsteroid = asteroid.Clone() as AbstractEnemy;

            halfAsteroid.Health.EndOfHpAction += Split;
            halfAsteroid.Health.EndOfHpAction += halfAsteroidView.Defeat;
            halfAsteroid.Transform = halfAsteroidView.Transform;
            halfAsteroid.Rigidbody = halfAsteroidView.RigidBody;
            halfAsteroidView.Interact += halfAsteroid.Interaction;

            
            halfAsteroid.SetTrajectory(Random.insideUnitCircle.normalized);

            asteroids.Add(halfAsteroid);
        }
    }
}

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

        private List<IEnemy> asteroids; 

        public AsteroidSpawnerModel(IEnemyFactory factory, AsteroidSpawnView spawnView, Transform rootTransform) 
        {
            _factory = factory;

            SpawnDistance = spawnView.SpawnDistance;           
            SpawnRate = spawnView.SpawnRate;
            AmountPerSpawn = spawnView.AmountPerSpawn;
            TrajectoryVariance = spawnView.TrajectoryVariance;

            _rootTransform = rootTransform;

            TimeBeforeSpawn = SpawnRate;

            asteroids = new List<IEnemy>();
        }

        public void Spawn()
        {
            if (TimeBeforeSpawn < SpawnRate) return;

            for (int i = 0; i < AmountPerSpawn; i++)
            {
                var position = GetPosition();
                var rotation = GetRotation();

                var asteroid = _factory.Create(EnemyType.Asteroid, position, rotation);

                asteroid.Health.EndOfHpAction += Split;

                asteroid.SetTrajectory(rotation * -position);

                asteroids.Add(asteroid);
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
            var asteroid = asteroids.Where(a => a.Health.CurrentHealth == 0).FirstOrDefault() as AsteroidModel;

            if (asteroid == null) return;
            

            if ((asteroid.Size * 0.5f ) >= asteroid.MinSize)
            {
                for (int i = 0; i < 2; i++)
                {
                    var newAsteroid = CreateSplit(asteroid);

                    newAsteroid.SetTrajectory(Random.insideUnitCircle.normalized * 20);

                    asteroids.Add(newAsteroid);
                }
            }

            asteroids.Remove(asteroid);

            Object.Destroy(asteroid.View.gameObject);
        }

        private AsteroidModel CreateSplit(AsteroidModel asteroid)
        {
            Vector2 position = asteroid.Transform.position;

            var rotation = GetRotation();

            var halfAsteroid = asteroid.Clone() as AsteroidModel;
            
            float newSize = asteroid.Size * 0.5f;
            halfAsteroid.View.Transform.position = position;
            halfAsteroid.View.Transform.localScale = Vector3.one * newSize;

            halfAsteroid.Size = newSize;

            halfAsteroid.Health.EndOfHpAction += Split;

            halfAsteroid.SetTrajectory(Random.insideUnitCircle.normalized * 10);

            return halfAsteroid;
        }
    }
}

﻿using GB_Asteroids.Enemy;
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

        public AsteroidSpawnerModel(IEnemyFactory factory, AsteroidSpawnView spawnView, Transform rootTransform) 
        {
            _factory = factory;

            SpawnDistance = spawnView.SpawnDistance;           
            SpawnRate = spawnView.SpawnRate;
            AmountPerSpawn = spawnView.AmountPerSpawn;
            TrajectoryVariance = spawnView.TrajectoryVariance;

            _rootTransform = rootTransform;

            TimeBeforeSpawn = SpawnRate;
        }

        public void Spawn()
        {
            if (TimeBeforeSpawn < SpawnRate) return;

            for (int i = 0; i < AmountPerSpawn; i++)
            {
                var postion = GetPosition();
                var rotation = GetRotation();

                var asteroid = _factory.Create(EnemyType.Asteroid, postion, rotation);

                asteroid.SetTrajectory(rotation * -postion);
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
    }
}
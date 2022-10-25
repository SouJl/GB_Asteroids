using System;
using UnityEngine;

namespace GB_Asteroids
{
    [Serializable]
    public class AsteroidSpawnView
    {
        [SerializeField] private EnemyFactory _factory;
        [SerializeField] private float _spawnDistance;
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private int amountPerSpawn = 1;
        [Range(0f, 45f)]
        [SerializeField] private float trajectoryVariance = 15f;

        public EnemyFactory Factory { get => _factory; set => _factory = value; }
        public float SpawnDistance { get => _spawnDistance; set => _spawnDistance = value; }
        public float SpawnRate { get => spawnRate; set => spawnRate = value; }
        public int AmountPerSpawn { get => amountPerSpawn; set => amountPerSpawn = value; }
        public float TrajectoryVariance { get => trajectoryVariance; set => trajectoryVariance = value; }
    }
}

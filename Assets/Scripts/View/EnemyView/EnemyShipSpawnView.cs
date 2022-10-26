using System;
using UnityEngine;

namespace GB_Asteroids
{
    [Serializable]
    public class EnemyShipSpawnView
    {
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private int amountPerSpawn = 1;

        public float SpawnRate { get => spawnRate; set => spawnRate = value; }
        public int AmountPerSpawn { get => amountPerSpawn; set => amountPerSpawn = value; }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    public class EnemyController : IExecute
    {
        private EnemySpawnerView _enemySpawner;

        private List<ISpawner> spawners;

        public EnemyController(EnemySpawnerView spawnerView) 
        {
            _enemySpawner = spawnerView;

            InitSpawners();
        }

        private void InitSpawners()
        {
            spawners = new List<ISpawner>();

            spawners.Add(new AsteroidSpawnerModel(_enemySpawner.EnemyFactory, _enemySpawner.AsteroidsSpawner, _enemySpawner.Transform));
        }

        public void Execute()
        {
            foreach(var spawner in spawners)
            {
                spawner.TimeBeforeSpawn += Time.deltaTime;
                spawner.Spawn();
            }
        }
    }
}

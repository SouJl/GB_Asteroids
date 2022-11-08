using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    public class EnemyController : IExecute
    {
        private EnemySpawnerView _enemySpawner;
        
        private Transform _target;
        
        private List<ISpawner> spawners;


        public EnemyController(EnemySpawnerView spawnerView, Transform target) 
        {
            _enemySpawner = spawnerView;
            _target = target;

            InitSpawners();
        }

        private void InitSpawners()
        {
            spawners = new List<ISpawner>();

            spawners.Add(new AsteroidSpawnerModel(_enemySpawner.EnemyFactory as CompositeEnemyFactory, _enemySpawner.AsteroidsSpawner, _enemySpawner.Transform));
            spawners.Add(new EnenemyShipSpawnerModel(_enemySpawner.EnemyFactory as CompositeEnemyFactory, _enemySpawner.EnemyShipSpawner, _target));
        }

        public void Execute()
        {
            foreach(var spawner in spawners)
            {
                spawner.TimeBeforeSpawn += Time.deltaTime;
                spawner.Spawn();
                
                if(spawner is EnenemyShipSpawnerModel ships)
                {
                    ships.Move();
                }
            }


        }
    }
}

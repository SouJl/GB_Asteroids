using GB_Asteroids.UI;
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

        private EnemyDestroyedLogView _logView;

        public EnemyController(EnemySpawnerView spawnerView, Transform target, EnemyDestroyedLogView logView) 
        {
            _enemySpawner = spawnerView;
            _target = target;
            _logView = logView;

            InitSpawners();
        }

        private void InitSpawners()
        {
            spawners = new List<ISpawner>();

            spawners.Add(new AsteroidSpawnerModel(_enemySpawner.EnemyFactory as CompositeEnemyFactory, _enemySpawner.AsteroidsSpawner, _enemySpawner.Transform));
            spawners.Add(new EnenemyShipSpawnerModel(_enemySpawner.EnemyFactory as CompositeEnemyFactory, _enemySpawner.EnemyShipSpawner, _target, _logView));
        }

        public void Execute()
        {
            foreach(var spawner in spawners)
            {
                spawner.Time += Time.deltaTime;
                spawner.Spawn();
                
                if(spawner is EnenemyShipSpawnerModel ships)
                {
                    ships.TimeBeforeFire += Time.deltaTime;

                    ships.Move();
                    ships.UseAbility();
                }
            }


        }

        public void FixedExecute()
        {
           
        }
    }
}

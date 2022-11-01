using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    public class EnenemyShipSpawnerModel : ISpawner
    {
        private float _spawnRate;
        private int _amountPerSpawn;
        private IEnemyFactory _factory;

        public float TimeBeforeSpawn { get; set; }
        public int AmountPerSpawn { get => _amountPerSpawn; set => _amountPerSpawn = value; }
        public float SpawnRate { get => _spawnRate; set => _spawnRate = value; }
        
        private Transform _targetTransform;
        
        private Camera _camera;
        private List<IEnemy> enemyShips;

        public EnenemyShipSpawnerModel(IEnemyFactory factory, EnemyShipSpawnView spawnView, Transform targetTransform)
        {
            _factory = factory;

            SpawnRate = spawnView.SpawnRate;
            AmountPerSpawn = spawnView.AmountPerSpawn;

            _targetTransform = targetTransform;
            _camera = Camera.main;

            //TimeBeforeSpawn = SpawnRate;

            enemyShips = new List<IEnemy>();
        }



        public void Spawn()
        {
            if (TimeBeforeSpawn < SpawnRate) return;

            for (int i = 0; i < AmountPerSpawn; i++)
            {
                var postion = GetPosition();
                var rotation = GetRotation();

                var enemy = _factory.Create(EnemyType.EnemyShip, postion, rotation).Clone();

                enemyShips.Add(enemy);
            }

            TimeBeforeSpawn = 0;
        }

        public Vector3 GetPosition()
        {
            var camHeight = _camera.orthographicSize;
            var vamWidth = camHeight * _camera.aspect;

            return new Vector3(0, camHeight - 3, 0);
        }

        public Quaternion GetRotation()
        {
            return Quaternion.identity;
        }

        public void Move()
        {
            foreach(var ship in enemyShips)
            {
                ship.SetTrajectory(_targetTransform.position);
            }
        }
    }
}

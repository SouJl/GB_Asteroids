using GB_Asteroids.Enemy;
using GB_Asteroids.FireModels;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GB_Asteroids
{
    public class EnenemyShipSpawnerModel : ISpawner
    {
        private float _spawnRate;
        private int _amountPerSpawn;
        private IEnemyFactory _factory;

        public float Time { get; set; }

        public float TimeBeforeFire { get; set; }

        public int AmountPerSpawn { get => _amountPerSpawn; set => _amountPerSpawn = value; }
        public float SpawnRate { get => _spawnRate; set => _spawnRate = value; }
        
        private Transform _targetTransform;
        
        private Camera _camera;
        private List<AbstractEnemy> enemyShips;
        private EnemyAbilityHandler enemyAbility;

        public EnenemyShipSpawnerModel(CompositeEnemyFactory factory, EnemyShipSpawnView spawnView, Transform targetTransform)
        {
            factory.AddFactory(EnemyType.EnemyShip);
            _factory = factory;

            SpawnRate = spawnView.SpawnRate;
            AmountPerSpawn = spawnView.AmountPerSpawn;

            _targetTransform = targetTransform;
            _camera = Camera.main;

            enemyShips = new List<AbstractEnemy>();

            var ability = new List<IAbility>
            {
                new Ability("Shoot bullet", 10, DamageType.Bullet),
                new Ability("Drop Bomb", 50, DamageType.Bomb)
            };
            enemyAbility = new EnemyAbilityHandler(ability);

        }

        public void Spawn()
        {
            if (Time < SpawnRate) return;

            for (int i = 0; i < AmountPerSpawn; i++)
            {
                var postion = GetPosition();
                var rotation = GetRotation();

                var enemy = _factory.Create(EnemyType.EnemyShip, postion, rotation) as AbstractEnemy;
                
                enemy.Health.EndOfHpAction += RemoveFromList;
                
                enemyShips.Add(enemy);
            }

            Time = 0;
        }

        public Vector3 GetPosition()
        {
            var camHeight = _camera.orthographicSize;
            var camWidth = camHeight * _camera.aspect;

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

        public void UseAbility() 
        {
            if (enemyShips.Count == 0)
            {
                TimeBeforeFire = 0;
                return;
            }

            int enemyId = Random.Range(0, enemyShips.Count);

            var ship = enemyShips[enemyId] as EnemyShipModel;

            if (TimeBeforeFire >= ship.FireRate) 
            {
                var ability = enemyAbility.GetAbility();
                ship.DealDamage(new AbilityFireModel(null, null, 10, ability));
                TimeBeforeFire = 0;
            }           
        }

        private void RemoveFromList(bool state) 
        {
            var removedEnemy = enemyShips.Where(e => e.Health.CurrentHealth == 0).ToList();
            foreach(var enemy in removedEnemy) 
            {
                enemyShips.Remove(enemy);
            }
        }
    }
}

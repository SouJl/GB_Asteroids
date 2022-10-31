using System;
using UnityEngine;

namespace GB_Asteroids.Enemy
{
    public class AsteroidModel : IEnemy
    {
        private string _name;
        private EnemyType _type;

        private float _damage;
        private float _points;
        private HealthModel _health;
        
        public string Name { get => _name; set => _name = value; }
        public EnemyType Type { get => _type; private set => _type = value; }
        
        public float Damage { get => _damage; set => _damage = value; }
        public float Points { get => _points; set => _points = value; }

        public HealthModel Health { get => _health; set => _health = value; }
        public Rigidbody Rigidbody { get => _rigidbody; private set => _rigidbody = value; }

        private EnemyConfig _config;
        private EnemyView _view;
        private Rigidbody _rigidbody;

        public AsteroidModel() { }

        public AsteroidModel(EnemyConfig config, EnemyView view) 
        {
            _config = config;

            Name = _config.Name;
            Type = _config.Type;
            Damage = _config.Damage;
            Points = _config.Points;

            Health = new HealthModel(_config.MaxHealth);
            
            _view = view;
            
            Health.EndOfHpAction += _view.Defeat;
           
            Rigidbody = _view.RigidBody;
            _view.Interact += Interaction;

        }

        public void SetTrajectory(Vector3 direction)
        {
            Rigidbody.AddForce(direction * 10);
        }


        public void Interaction(Collider collider) 
        {
            if(collider.tag == "Bullet") 
            {
                TakeDamage(10);
                collider.GetComponent<BulletView>().DestroyBullet();
            }
        }

        public void DealDamage()
        {
            
        }

        public void TakeDamage(float amount)
        {
            Health.ChangeCurrentHp(Health.CurrentHealth - amount);
            Debug.Log($"{Name} Hp = {Health.CurrentHealth}");
        }

        public IEnemy Clone() 
        {
            var result = new AsteroidModel();
            
            result.Name = _config.Name;
            result.Type = _config.Type;
            result.Damage = _config.Damage;
            result.Points = _config.Points;

            result.Health = new HealthModel(_config.MaxHealth);

            result.Health.EndOfHpAction += _view.Defeat;

            result.Rigidbody = _view.RigidBody;
            _view.Interact += result.Interaction;

            return result;
        }
    }
}

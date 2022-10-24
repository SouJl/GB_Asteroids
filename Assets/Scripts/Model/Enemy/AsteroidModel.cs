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
        public EnemyType Type { get => _type; }
        
        public float Damage { get => _damage; set => _damage = value; }
        public float Points { get => _points; set => _points = value; }


        public HealthModel Health { get => _health; set => _health = value; }

        private Transform _transform;

        public AsteroidModel(EnemyConfig config, Transform transform) 
        {
            Name = config.Name;
            _type = config.Type;
            Damage = config.Damage;
            Points = config.Points;

            Health = new HealthModel(config.MaxHealth);

            _transform = transform;
        }


        public void Interaction(Collider collider) 
        {
            if(collider.tag == "Bullet") 
            {
                TakeDamage(10);
                UnityEngine.Object.Destroy(collider.gameObject);
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
    }
}

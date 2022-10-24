using UnityEngine;

namespace GB_Asteroids.Enemy
{
    public class EnemyShipModel : IEnemy
    {
        private float _damage;
        private float _points;
        private EnemyType _type;

        private HealthModel _health;

        public float Damage { get => _damage; set => _damage = value; }
        public float Points { get => _points; set => _points = value; }
        public EnemyType Type { get => _type; }

        public HealthModel Health { get => _health; set => _health = value; }
        
        private Transform _transform;

        public EnemyShipModel(EnemyConfig config, Transform transform)
        {
            _type = config.Type;
            Damage = config.Damage;
            Points = config.Points;

            Health = new HealthModel(config.MaxHealth);

            _transform = transform;
        }

        public void DealDamage()
        {

        }

        public void TakeDamage(float amount)
        {
            Health.ChangeCurrentHp(Health.CurrentHealth - amount);
        }
    }
}

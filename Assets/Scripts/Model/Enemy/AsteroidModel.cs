using UnityEngine;

namespace GB_Asteroids.Enemy
{
    public class AsteroidModel : IEnemy
    {
        private HealthModel _health;
        
        public HealthModel Health { get => _health; set => _health = value; }

        public void DealDamage()
        {
            
        }

        public void TakeDamage(float amount)
        {
            Health.ChangeCurrentHp(Health.CurrentHealth - amount);
        }
    }
}

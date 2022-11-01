using UnityEngine;

namespace GB_Asteroids
{
    public interface IEnemy
    {
        public float Damage { get; set; }
        public float Points { get; set; }
        public EnemyType Type { get; }

        HealthModel Health { get;}

        void SetTrajectory(Vector3 direction);

        void DealDamage();

        void TakeDamage(float amout);

        IEnemy Clone();
    }
}

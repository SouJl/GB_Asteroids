using System;
using UnityEngine;

namespace GB_Asteroids.Enemy
{
    public class AsteroidModel : AbstractEnemy
    {

        public AsteroidModel(EnemyConfig config, EnemyView view):base(config, view) 
        {

        }

        public AsteroidModel(AsteroidModel source) : base(source) 
        {

        }
        
        public override void SetTrajectory(Vector3 direction)
        {
            Rigidbody.AddForce(direction * 10);
        }

        public override void DealDamage()
        {
            
        }

        public override void TakeDamage(float amount)
        {
            Health.ChangeCurrentHp(Health.CurrentHealth - amount);
            Debug.Log($"{Name} Hp = {Health.CurrentHealth}");
        }

        public override void Interaction(Collider collider)
        {
            base.Interaction(collider);
        }

        public override IEnemy Clone() => new AsteroidModel(this);
    }
}

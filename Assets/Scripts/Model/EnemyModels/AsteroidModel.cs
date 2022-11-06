using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GB_Asteroids.Enemy
{
    public class AsteroidModel : AbstractEnemy
    {
        private float _size;
        private float _minSize;

        public float Size { get => _size; set => _size = value; }
        public float MinSize { get => _minSize;}

        public AsteroidModel(AsteroidView view) : base(view) 
        {
            Size = view.Size;
            _minSize = view.MinSize;
        }

        public AsteroidModel(EnemyConfig config, EnemyView view):base(config, view) 
        {

        }

        public AsteroidModel(AsteroidModel source) : base(source) 
        {
            _minSize = source.MinSize;
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

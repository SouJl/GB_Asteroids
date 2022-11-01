using UnityEngine;

namespace GB_Asteroids.Enemy
{
    public class EnemyShipModel : AbstractEnemy
    {
        private Transform _transform;

        public EnemyShipModel(EnemyConfig config, EnemyView view):base(config, view) 
        {
            _transform = View.Transform;
        }

        public EnemyShipModel(EnemyShipModel source) : base(source) 
        {
            _transform = View.Transform;
        }

        public override void SetTrajectory(Vector3 direction)
        {
            Vector3 target = (direction - _transform.position).normalized;
            Rigidbody.MovePosition(_transform.position + target * 15 * Time.deltaTime);
        }

        public override void DealDamage()
        {

        }

        public override void TakeDamage(float amount)
        {
            Health.ChangeCurrentHp(Health.CurrentHealth - amount);
        }

        public override void Interaction(Collider collider)
        {
            base.Interaction(collider);
        }
        
        public override IEnemy Clone() => new EnemyShipModel(this); 
    }
}

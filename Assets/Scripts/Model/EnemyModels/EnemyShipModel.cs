using UnityEngine;

namespace GB_Asteroids.Enemy
{
    public class EnemyShipModel : AbstractEnemy, IMove, IRotation
    {
        private Transform _transform;
        
        private float _fireRate;

        public float FireRate { get => _fireRate; private set => _fireRate = value; }

        public EnemyShipModel(EnemyShipConfig config, EnemyView view):base(config, view) 
        {
            _transform = view.Transform;
            FireRate = config.FireRate;
        }

        public EnemyShipModel(EnemyShipModel source) : base(source) 
        {
            _transform = View.Transform;
        }

        public override void SetTrajectory(Vector3 direction)
        {
            Vector3 targetDirection = direction - _transform.position;

            Move(Rigidbody, targetDirection);
            Rotate(Rigidbody, targetDirection);
        }

        public void Move(Rigidbody rigidbody, Vector3 input)
        {
            input.Normalize();
            rigidbody.MovePosition(rigidbody.position + input * 5 * Time.deltaTime);
        }

        public void Rotate(Rigidbody rigidbody, Vector3 input)
        {
            float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
            Vector3 eulerAngleVelocity = new Vector3(0, 0, angle + 90);
            Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity);
            rigidbody.MoveRotation(deltaRotation);
        }

        public override void DealDamage(IFire fire)
        {
            fire.Fire();
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

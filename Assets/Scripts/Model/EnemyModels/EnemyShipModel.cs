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
        private Rigidbody _rigidbody;

        public EnemyShipModel(EnemyConfig config, EnemyView view)
        {
            _type = config.Type;
            Damage = config.Damage;
            Points = config.Points;

            Health = new HealthModel(config.MaxHealth);

            _transform = view.transform;
            _rigidbody = view.RigidBody;
            view.Interact += Interaction;
        }


        public void SetTrajectory(Vector3 direction)
        {
            Vector3 target = (direction - _transform.position).normalized;
            _rigidbody.MovePosition(_transform.position + target * 15 * Time.deltaTime);
            //_rigidbody.MoveRotation(Quaternion.LookRotation(_transform.position - direction));
        }

        public void DealDamage()
        {

        }

        public void TakeDamage(float amount)
        {
            Health.ChangeCurrentHp(Health.CurrentHealth - amount);
        }

        public void Interaction(Collider collider)
        {
            if (collider.tag == "Bullet")
            {
                TakeDamage(10);
                collider.GetComponent<BulletView>().DestroyBullet();
            }
        }

        public IEnemy Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}

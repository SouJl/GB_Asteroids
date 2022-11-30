using System;
using UnityEngine;

namespace GB_Asteroids
{
    public abstract class AbstractEnemy : IEnemy, IInteract
    {
        private string _name;
        private EnemyType _type;

        private float _damage;
        private float _points;
        private float _maxHealth;

        private HealthModel _health;
        private EnemyView _view;
        private Rigidbody _rigidbody;
        private Transform _transform;

        public string Name { get => _name; set => _name = value; }
        public EnemyType Type { get => _type; private set => _type = value; }

        public float Damage { get => _damage; set => _damage = value; }
        public float Points { get => _points; set => _points = value; }
        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }

        public HealthModel Health { get => _health; private set => _health = value; }
        public EnemyView View { get => _view; private set => _view = value; }
        public Transform Transform { get => _transform;  set => _transform = value; }

        public AbstractEnemy(EnemyView view)
        {
            Name = view.name;
            Type = view.Type;
            Damage = view.Damage;
            Points = view.Points;
            MaxHealth = view.MaxHealth;
            View = view;
            
            Health = new HealthModel(MaxHealth, View.name);

            Rigidbody = View.RigidBody;
            Transform = View.Transform;
            View.Interact += Interaction;
        }

        public AbstractEnemy(EnemyConfig config, EnemyView view) 
        {
            Name = config.Name;
            Type = config.Type;
            Damage = config.Damage;
            Points = config.Points;
            MaxHealth = config.MaxHealth;
            View = view;

            Health = new HealthModel(MaxHealth, View.name);
            Rigidbody = View.RigidBody;
            View.Interact += Interaction;
        }

        public AbstractEnemy(AbstractEnemy source) 
        {
            View = source.View.Clone();

            Rigidbody = View.RigidBody;
            Transform = View.Transform;
            View.Interact += Interaction;

            Name = source.Name;
            Type = source.Type;
            Damage = source.Damage;
            Points = source.Points;
            MaxHealth = source.MaxHealth;

            Health = new HealthModel(MaxHealth, View.name);
        }

        public abstract IEnemy Clone();

        public abstract void DealDamage(IFire fire);

        public abstract void TakeDamage(float amount);

        public abstract void SetTrajectory(Vector3 direction);

        public virtual void Interaction(Collider collider) 
        {
            if (collider.tag == "Bullet")
            {
                TakeDamage(10);
                collider.GetComponent<BulletView>().DestroyBullet();
            }
        }
    }
}

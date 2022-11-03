using System;
using UnityEngine;

namespace GB_Asteroids
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyView: BaseView
    {

        [SerializeField] private Rigidbody _rigidBody;

        [SerializeField] private EnemyType _type;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _damage;
        [SerializeField] private float _points;

        public Rigidbody RigidBody { get => _rigidBody; set => _rigidBody = value; }

        public EnemyType Type { get => _type; set => _type = value; }
        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public float Damage { get => _damage; set => _damage = value; }
        public float Points { get => _points; set => _points = value; }

        public event Action<Collider> Interact;

        protected override void Awake()
        {
            base.Awake();
            RigidBody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Interact?.Invoke(other);
        }

        public void OutOfBounds() 
        {
            Defeat(false);
        }

        public void Defeat(bool state)
        {
            Destroy(gameObject);
            //ServiceLocator.Resolve<IViewService>().Destroy(gameObject);
        }
    }
}

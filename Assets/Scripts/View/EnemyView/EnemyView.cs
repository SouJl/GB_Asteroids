using System;
using UnityEngine;

namespace GB_Asteroids
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyView: BaseView
    {
        [SerializeField] private Rigidbody _rigidBody;

        public Rigidbody RigidBody { get => _rigidBody; set => _rigidBody = value; }

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

        public void Defeat(bool state)
        {
            gameObject.SetActive(false);
        }
    }
}

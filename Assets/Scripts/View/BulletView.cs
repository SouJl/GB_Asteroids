﻿using UnityEngine;

namespace GB_Asteroids
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private float _damage;
        
        private Rigidbody _rigidbody;
        private BoundsCheck _boundsCheck;

        public float Damage { get => _damage; set => _damage = value; }
        public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            _boundsCheck = GetComponent<BoundsCheck>();
        }

        private void Update()
        {
            if (!_boundsCheck) return;

            if (_boundsCheck.IsOutOfBounds()) 
            {
                DestroyBullet();
            }
        }

        public void DestroyBullet() 
        {
            Rigidbody.velocity = Vector3.zero;
            ServiceLocator.Resolve<IViewBuilderService>().Destroy(gameObject);
        }

    }
}

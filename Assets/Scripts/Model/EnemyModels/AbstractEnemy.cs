﻿using System;
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

        public string Name { get => _name; set => _name = value; }
        public EnemyType Type { get => _type; private set => _type = value; }

        public float Damage { get => _damage; set => _damage = value; }
        public float Points { get => _points; set => _points = value; }
        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }

        public HealthModel Health { get => _health; private set => _health = value; }
        public Rigidbody Rigidbody { get => _rigidbody; private set => _rigidbody = value; }
        public EnemyView View { get => _view; private set => _view = value; }

        public AbstractEnemy(EnemyConfig config, EnemyView view) 
        {
            Name = config.Name;
            Type = config.Type;
            Damage = config.Damage;
            Points = config.Points;
            MaxHealth = config.MaxHealth;

            Health = new HealthModel(MaxHealth);

            View = view;
            Health.EndOfHpAction += View.Defeat;
            Rigidbody = View.RigidBody;
            View.Interact += Interaction;
        }

        public AbstractEnemy(AbstractEnemy source) 
        {
            Name = source.Name;
            Type = source.Type;
            Damage = source.Damage;
            Points = source.Points;
            MaxHealth = source.MaxHealth;

            Health = new HealthModel(MaxHealth);

            View = source.View;
            Health.EndOfHpAction += View.Defeat;
            Rigidbody = View.RigidBody;
            View.Interact += Interaction;
        }

        public abstract IEnemy Clone();

        public abstract void DealDamage();

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
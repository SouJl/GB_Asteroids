using System;
using UnityEngine;

namespace GB_Asteroids
{
    public class EnemyView: BaseView
    {
        public event Action<Collider> Interact;

        protected override void Awake()
        {
            base.Awake();
        }

        private void OnTriggerEnter(Collider other)
        {
            Interact?.Invoke(other);
        }
    }
}

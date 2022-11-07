using UnityEngine;

namespace GB_Asteroids.FireModels
{
    public abstract class BaseFireModel : IFire
    {
        private SimpleObjectConfig _bulletConfig;

        private Transform _firePoint;

        private float _force;

        public SimpleObjectConfig BulletConfig { get => _bulletConfig; set => _bulletConfig = value; }
        public Transform FirePoint { get => _firePoint; set => _firePoint = value; }
        public float Force { get => _force;  set => _force = value; }


        public BaseFireModel(SimpleObjectConfig bulletConfig, Transform firePoint, float force) 
        {
            BulletConfig = bulletConfig;
            FirePoint = firePoint;
            Force = force;
        }


        public abstract void Fire();
    }
}

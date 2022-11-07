using GB_Asteroids.FireModels;
using UnityEngine;

namespace GB_Asteroids
{
    public class FireFactory
    {
        private SimpleObjectConfig _bulletConfig;

        private Transform _firePoint;

        private float _force;

        public FireFactory(SimpleObjectConfig bulletConfig, Transform firePoint, float force) 
        {
            _bulletConfig = bulletConfig;
            _firePoint = firePoint;
            _force = force;
        }

        public IFire GetFireModel(FireType type) 
        {
            switch (type) 
            {
                default:
                    return null;
                case FireType.Blaster: 
                    {
                        return new BlasterFireModel(_bulletConfig, _firePoint, _force);
                    }
                case FireType.Spread: 
                    {
                        return new SpreadFireModel(_bulletConfig, _firePoint, _force);
                    }

            }
        }
    }
}

using GB_Asteroids.Builder;
using UnityEngine;

namespace GB_Asteroids
{
    public class WeaponModel : IWeapon
    {
        private float _fireForce;
        private int _fireRate;
        private Transform _firePoint;
        private SimpleObjectConfig _bulletConfig;

        public int FireRate { get => _fireRate; set => _fireRate = value; }
        public Transform FirePoint { get => _firePoint; set => _firePoint = value; }
        public SimpleObjectConfig BulletConfig { get => _bulletConfig; set => _bulletConfig = value; }
        public float FireForce { get => _fireForce; set => _fireForce = value; }

        private IViewService _viewService;

        public WeaponModel(WeaponView view) 
        {
            FireForce = view.FireForce;
            FireRate = view.FireRate;
            FirePoint = view.FirePoint;
            BulletConfig = view.BulletConfig;

            _viewService = new ViewBuilderService(20);

        }

        public void Fire()
        {         
            var bullet = _viewService.Instantiate<Transform>(BulletConfig, FirePoint);

            BulletView view = bullet.gameObject.AddComponent<BulletView>();
            view.ViewService = _viewService;
            view.Rigidbody.AddForce(FirePoint.up * FireForce, ForceMode.Force);
        }   
    }
}

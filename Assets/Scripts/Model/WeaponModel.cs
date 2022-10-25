using UnityEngine;

namespace GB_Asteroids
{
    public class WeaponModel : IWeapon
    {
        private float _fireForce;
        private int _fireRate;
        private Transform _firePoint;
        private GameObject _bulletPrefab;

        public int FireRate { get => _fireRate; set => _fireRate = value; }
        public Transform FirePoint { get => _firePoint; set => _firePoint = value; }
        public GameObject BulletPrefab { get => _bulletPrefab; set => _bulletPrefab = value; }
        public float FireForce { get => _fireForce; set => _fireForce = value; }

        private IViewService _viewService;

        public WeaponModel(WeaponView view) 
        {
            FireForce = view.FireForce;
            FireRate = view.FireRate;
            FirePoint = view.FirePoint;
            BulletPrefab = view.Bullet;

            _viewService = new ViewService(20);
        }

        public void Fire()
        {
            var bullet = _viewService.Instantiate<BulletView>(_bulletPrefab, FirePoint);
            
            bullet.ViewService = _viewService;

            bullet.Rigidbody.AddForce(FirePoint.up * FireForce, ForceMode.Force);
        }   
    }
}

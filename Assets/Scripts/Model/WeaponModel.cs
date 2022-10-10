using UnityEngine;

namespace GB_Asteroids
{
    public class WeaponModel : IWeapon
    {
        private float _damage;
        private int _fireRate;
        private Transform _firePoint;
        private GameObject _bulletPrefab;

        public float Damage { get => _damage; set => _damage = value; }
        public int FireRate { get => _fireRate; set => _fireRate = value; }
        public Transform FirePoint { get => _firePoint; set => _firePoint = value; }
        public GameObject BulletPrefab { get => _bulletPrefab; set => _bulletPrefab = value; }

        public WeaponModel(WeaponView view) 
        {
            Damage = view.Damage;
            FireRate = view.FireRate;
            FirePoint = view.FirePoint;
            BulletPrefab = view.Bullet;
        }

        public void Fire()
        {
            var bullet = ProcessesSingleton.Instance.SpawnObject(BulletPrefab, FirePoint.position);
            bullet.GetComponent<Rigidbody>().AddForce(FirePoint.up * 500, ForceMode.Force);
        }   
    }
}

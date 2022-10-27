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
        private GameObjectBuilder _builder;

        public WeaponModel(WeaponView view) 
        {
            FireForce = view.FireForce;
            FireRate = view.FireRate;
            FirePoint = view.FirePoint;
            BulletConfig = view.BulletConfig;

            _viewService = new ViewService(20);
            _builder = new GameObjectBuilder();
        }

        public void Fire()
        {
            var bulletPref = BuildBullet(BulletConfig);
           
            var bullet = _viewService.Instantiate<BulletView>(bulletPref, FirePoint);

            bullet.ViewService = _viewService;

            bullet.Rigidbody.AddForce(FirePoint.up * FireForce, ForceMode.Force);
        }   

        private GameObject BuildBullet(SimpleObjectConfig config)
        {
            return _builder
                .Visual
                .Size(config.Size)
                .Name(config.Name)
                .MeshFilter(config.Mesh)
                .MeshRenderer(config.Material)
                .Physics
                .Rigidbody(config.RigidProperies)
                .SphereCollider(1)
                .Script
                .SetMainView<BulletView>()
                .BoundsCheck(false);
        }
    }
}

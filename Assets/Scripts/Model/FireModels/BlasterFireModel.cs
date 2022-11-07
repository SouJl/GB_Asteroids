using UnityEngine;

namespace GB_Asteroids.FireModels
{
    public class BlasterFireModel : BaseFireModel
    {
        public BlasterFireModel(SimpleObjectConfig bulletConfig, Transform firePoint, float force) : base( bulletConfig, firePoint, force) 
        {

        }

        public override void Fire()
        {
            var bullet = ServiceLocator.Resolve<IViewBuilderService>().Instantiate<Transform>(BulletConfig);

            bullet.transform.position = FirePoint.position;
            bullet.transform.rotation = Quaternion.identity;

            BulletView view = bullet.gameObject.AddComponent<BulletView>();

            view.Rigidbody.AddForce(FirePoint.up * Force, ForceMode.Force);
        }
    }
}

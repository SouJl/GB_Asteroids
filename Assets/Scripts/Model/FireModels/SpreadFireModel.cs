using UnityEngine;

namespace GB_Asteroids.FireModels
{
    public class SpreadFireModel : BaseFireModel
    {

        public SpreadFireModel(SimpleObjectConfig bulletConfig, Transform firePoint, float force) : base(bulletConfig, firePoint, force) 
        {

        }


        public override void Fire() 
        { 
            var bulletLeft = MakeProjectile(); 
            var bulletCentr = MakeProjectile(); 
            var bulletRight = MakeProjectile(); 
 
            bulletLeft.Rigidbody.AddForce(FireAngle(10) * Force, ForceMode.Force); 
            bulletCentr.Rigidbody.AddForce(FireAngle(0)* Force, ForceMode.Force); 
            bulletRight.Rigidbody.AddForce(FireAngle(-10) * Force, ForceMode.Force); 
        } 
 
        private BulletView MakeProjectile() 
        { 
            var bullet = ServiceLocator.Resolve<IViewBuilderService>().Instantiate<Transform>(BulletConfig); 
            bullet.transform.position = FirePoint.position; 
 
            return bullet.gameObject.AddComponent<BulletView>(); 
        } 
 
        private Vector3 FireAngle(float angle) 
        {
            return Quaternion.AngleAxis(angle, Vector3.back) * FirePoint.up;          
        }
    }
}

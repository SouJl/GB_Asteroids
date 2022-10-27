using UnityEngine;

namespace GB_Asteroids 
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private float _fireForce;
        [SerializeField] private int _fireRate;
        [SerializeField] private SimpleObjectConfig _bulletConfig;
        [SerializeField] private Transform _firePoint;

        public Transform FirePoint { get => _firePoint; private set => _firePoint = value; }
        public int FireRate { get => _fireRate; private set => _fireRate = value; }
        public SimpleObjectConfig BulletConfig { get => _bulletConfig; private set => _bulletConfig = value; }
        public float FireForce { get => _fireForce; private set => _fireForce = value; }
    }
}


using UnityEngine;

namespace GB_Asteroids
{

    public class FireConfig : ScriptableObject
    {
        [SerializeField] private SimpleObjectConfig _bulletConfig;
        [SerializeField] private Transform _firePoint;

        [SerializeField] private float _fireForce;

        public SimpleObjectConfig BulletConfig { get => _bulletConfig; private set => _bulletConfig = value; }
        public Transform FirePoint { get => _firePoint; private set => _firePoint = value; }
        public float FireForce { get => _fireForce; private set => _fireForce = value; }
    }
}

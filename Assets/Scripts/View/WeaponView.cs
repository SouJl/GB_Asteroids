using UnityEngine;

namespace GB_Asteroids 
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;

        [SerializeField] private FireType _fireType;

        [SerializeField] private SimpleObjectConfig _bulletConfig;
        [SerializeField] private int _fireRate;
        [SerializeField] private float _fireForce;

        [Header("LaserSight Settings")]
        [SerializeField] private Transform _laserSightPosition;
        [SerializeField] private GameObject _laserSightPrefab;

        public Transform FirePoint { get => _firePoint; set => _firePoint = value; }
        public FireType FireType { get => _fireType;  set => _fireType = value; }

        public SimpleObjectConfig BulletConfig { get => _bulletConfig;  set => _bulletConfig = value; }
        public int FireRate { get => _fireRate;  set => _fireRate = value; }
        public float FireForce { get => _fireForce;  set => _fireForce = value; }
        public Transform LaserSightPosition { get => _laserSightPosition; set => _laserSightPosition = value; }
        public GameObject LaserSightPrefab { get => _laserSightPrefab; set => _laserSightPrefab = value; }
    }
}


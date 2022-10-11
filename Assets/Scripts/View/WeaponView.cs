using UnityEngine;


namespace GB_Asteroids 
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private float _fireForce;
        [SerializeField] private int _fireRate;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _firePoint;

        public Transform FirePoint { get => _firePoint; set => _firePoint = value; }
        public int FireRate { get => _fireRate; set => _fireRate = value; }
        public GameObject Bullet { get => _bullet; set => _bullet = value; }
        public float FireForce { get => _fireForce; set => _fireForce = value; }
    }
}


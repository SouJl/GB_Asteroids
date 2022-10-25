using UnityEngine;

namespace GB_Asteroids
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private float _damage;
        
        private Rigidbody _rigidbody;
        private BoundsCheck _boundsCheck;
        private IViewService viewService;

        public float Damage { get => _damage; set => _damage = value; }
        public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }
        public IViewService ViewService { get => viewService; set => viewService = value; }

        void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            _boundsCheck = GetComponent<BoundsCheck>();
        }

        private void Update()
        {
            if (!_boundsCheck) return;
            if (viewService == null) return;

            if (_boundsCheck.IsOutOfBounds()) 
            {
                DestroyBullet();
            }
        }

        public void DestroyBullet() 
        {
            Rigidbody.velocity = Vector3.zero;
            viewService.Destroy(gameObject);
        }

    }
}

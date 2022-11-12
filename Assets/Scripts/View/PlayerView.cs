using UnityEngine;

namespace GB_Asteroids 
{
    [RequireComponent(typeof(EngineView), typeof(RotatorView))]
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private float _hp = 150f;

        private EngineView _engine;
        private WeaponView _weapon;
        private RotatorView _rotator;
        private Rigidbody _rigidbody;
        public float Hp { get => _hp; set => _hp = value; }
        
        public WeaponView Weapon { get => _weapon; private set => _weapon = value; }
        public EngineView Engine { get => _engine; private set => _engine = value; }
        public RotatorView Rotator { get => _rotator; private set => _rotator = value; }
        public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }

        private void Awake()
        {
            Weapon = GetComponent<WeaponView>();
            Engine = GetComponent<EngineView>();
            Rotator = GetComponent<RotatorView>();
            Rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy")) 
            {
                Rigidbody rbdy = gameObject.GetComponent<Rigidbody>();
                rbdy.velocity = Vector3.zero;
                rbdy.angularVelocity = Vector3.zero;
            }
        }
    }
}


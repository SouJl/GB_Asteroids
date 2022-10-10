using UnityEngine;

namespace GB_Asteroids
{
    [RequireComponent(typeof(Rigidbody))]
    public class EngineView : MonoBehaviour
    {
        [SerializeField] private float _power;
        [SerializeField] private ForceMode _forceMode;
        [SerializeField] private Rigidbody _rigidbody;

        public float Power { get => _power; set => _power = value; }
        public ForceMode ForceMode { get => _forceMode; set => _forceMode = value; }
        public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}

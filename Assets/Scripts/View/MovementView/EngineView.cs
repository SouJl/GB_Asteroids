using UnityEngine;

namespace GB_Asteroids
{
    [RequireComponent(typeof(Rigidbody))]
    public class EngineView : MonoBehaviour
    {
        [SerializeField] private MovementType _type;

        [SerializeField] private float _power;
        [SerializeField] private ForceMode _forceMode;
        [SerializeField] private Rigidbody _rigidbody;


        public MovementType Type 
        { 
            get => _type;
            set => _type = value;
        }


        public float Power { get => _power; set => _power = value; }
        public ForceMode ForceMode { get => _forceMode; set => _forceMode = value; }
        public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }

        private MovementType _prevType = MovementType.None;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnDrawGizmos()
        {
            if (_type != _prevType) 
            {
                switch (Type)
                {
                    default: 
                        {
                            Power = 0;
                            break;
                        }

                    case MovementType.Force:
                        {
                            Power = 1;
                            break;
                        }
                    case MovementType.Dash:
                        {
                            Power = 300;
                            break;
                        }
                }

                _prevType = _type;
            }          
        }
    }
}

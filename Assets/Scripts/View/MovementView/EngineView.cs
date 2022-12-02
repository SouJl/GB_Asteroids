using UnityEngine;

namespace GB_Asteroids
{
    [RequireComponent(typeof(Rigidbody))]
    public class EngineView : MonoBehaviour
    {
        [SerializeField] private MovementType _type;

        [SerializeField] private float _power;
        [SerializeField] private ForceMode _forceMode;


        public MovementType Type 
        { 
            get => _type;
            set => _type = value;
        }


        public float Power { get => _power; set => _power = value; }
        public ForceMode ForceMode { get => _forceMode; set => _forceMode = value; }

        private MovementType _prevType = MovementType.None;
    }
}

using UnityEngine;

namespace GB_Asteroids
{
    public class EngineModel : IEngine
    {
        private float _power;
        private ForceMode _forceMode;
        private Rigidbody _rigidbody;

        public float Power { get => _power; set => _power = value; }
        public ForceMode ForceMode { get => _forceMode; set => _forceMode = value; }
        public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }

        public EngineModel(EngineView view) 
        {
            Power = view.Power;
            ForceMode = view.ForceMode;
            Rigidbody = view.Rigidbody;
        }

        public void AddForce(Vector3 direction)
        {
            Rigidbody.AddForce(direction * Power, ForceMode);
        }
    }
}

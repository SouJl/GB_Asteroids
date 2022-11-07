using UnityEngine;

namespace GB_Asteroids.Movement
{
    public class ForceMoveModel : IMove
    {
        private Rigidbody _rigidbody;
        private float _power;
        private ForceMode _mode;

        public ForceMoveModel(Rigidbody rigidbody, float power, ForceMode mode) 
        {
            _rigidbody = rigidbody;
            _mode = mode;
            _power = power;
        }

        public void Move(Vector3 input)
        {
            _rigidbody.AddForce(input * _power, _mode);
        }
    }
}

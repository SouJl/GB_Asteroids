using UnityEngine;

namespace GB_Asteroids.Movement
{
    public class DashMoveModel : IMove
    {
        private Rigidbody _rigidbody;
        private float _power;
        private ForceMode _mode;

        private float _resultPower = 0;
        private Vector3 _direction;

        public DashMoveModel(Rigidbody rigidbody, float power, ForceMode mode)
        {
            _rigidbody = rigidbody;
            _mode = mode;
            _power = power;
        }

        public void Move(Vector3 input)
        {
            if(input != Vector3.zero) 
            {
                _resultPower += 1f;
                if (_resultPower >= _power) _resultPower = _power;

                _direction = input;

                Debug.Log(_resultPower);
            }
            else 
            {
                _rigidbody.AddForce(_direction * _resultPower, _mode);
                _resultPower = 0;
            }
                    
        }
    }
}

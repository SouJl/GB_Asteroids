using UnityEngine;

namespace GB_Asteroids.Movement
{
    public class DashMoveModel : IMove
    {
        private float _power;
        private ForceMode _mode;

        private float _resultPower = 0;
        private Vector3 _direction;

        public DashMoveModel(float power, ForceMode mode)
        {
            _mode = mode;
            _power = power;
        }

        public void Move(Rigidbody rigidbody, Vector3 input)
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
                rigidbody.AddForce(_direction * _resultPower, _mode);
                _resultPower = 0;
            }
                    
        }
    }
}

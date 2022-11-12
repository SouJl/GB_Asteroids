using UnityEngine;

namespace GB_Asteroids.Movement
{
    public class ForceMoveModel : IMove
    {
        private float _power;
        private ForceMode _mode;

        public ForceMoveModel(float power, ForceMode mode) 
        {
            _mode = mode;
            _power = power;
        }

        public void Move(Rigidbody rigidbody, Vector3 input)
        {
            rigidbody.AddForce(input * _power, _mode);
        }
    }
}

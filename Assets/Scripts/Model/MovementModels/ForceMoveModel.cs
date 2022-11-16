using UnityEngine;

namespace GB_Asteroids.Movement
{
    public class ForceMoveModel : IMove
    {
        private ForceMode _mode;

        public ForceMoveModel(float power, ForceMode mode) 
        {
            _mode = mode;
        }

        public void Move(Rigidbody rigidbody, Vector3 input)
        {
            rigidbody.AddForce(input, _mode);
        }
    }
}

using UnityEngine;

namespace GB_Asteroids
{
    public class RotatorModel : IRotation
    {
        private float _rotationSpeed;

        public float RotationSpeed { get => _rotationSpeed; set => _rotationSpeed = value; }

        public RotatorModel(float rotationSpeed) 
        {
            RotationSpeed = rotationSpeed;
        }

        public void Rotate(Rigidbody rigidbody, Vector3 input)
        {
            Quaternion deltaRotation = Quaternion.Euler(input * RotationSpeed * Time.deltaTime);
            rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
        }
    }
}

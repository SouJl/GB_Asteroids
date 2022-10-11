using UnityEngine;

namespace GB_Asteroids
{
    public class RotatorModel : IRotation
    {
        private float _rotationSpeed;
        private Transform _toRotateTransform;

        public float RotationSpeed { get => _rotationSpeed; set => _rotationSpeed = value; }
        public Transform ToRotateTransform { get => _toRotateTransform; private set => _toRotateTransform = value; }

        public RotatorModel(RotatorView view, Transform toRotate) 
        {
            RotationSpeed = view.RotationSpeed;
            ToRotateTransform = toRotate;
        }

        public void Rotate(Vector3 input)
        {
            ToRotateTransform.Rotate(input * RotationSpeed * Time.deltaTime);
        }
    }
}

using UnityEngine;

namespace GB_Asteroids
{
    public class RotatorView : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 180f;

        public float RotationSpeed { get => _rotationSpeed; set => _rotationSpeed = value; }
    }
}

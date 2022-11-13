using UnityEngine;

namespace GB_Asteroids
{
    public interface IRotation
    {
        void Rotate(Rigidbody rigidbody, Vector3 input);
    }
}

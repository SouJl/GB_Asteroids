using UnityEngine;

namespace GB_Asteroids
{
    public abstract class AbstractUnit : IMove, IRotation
    {
        public abstract void Move(Rigidbody rigidbody, Vector3 input);

        public abstract void Rotate(Rigidbody rigidbody, Vector3 input);
    }
}

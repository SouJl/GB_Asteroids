using UnityEngine;

namespace GB_Asteroids
{
    public interface IMove
    {
        void Move(Rigidbody rigidbody,  Vector3 input);
    }
}

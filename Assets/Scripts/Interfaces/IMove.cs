using UnityEngine;

namespace GB_Asteroids
{
    public interface IMove
    {
        float Speed { get; set; }

        void Move(Vector2 input);
    }
}

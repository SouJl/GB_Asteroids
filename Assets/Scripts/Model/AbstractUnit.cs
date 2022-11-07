using UnityEngine;

namespace GB_Asteroids
{
    public abstract class AbstractUnit : IMove
    {
        public void Move(Vector3 input) 
        {
            ChangePosotion(input);
            ChangeRotation(input);
        }

        protected abstract void ChangePosotion(Vector2 input);

        protected abstract void ChangeRotation(Vector2 input);
    }
}

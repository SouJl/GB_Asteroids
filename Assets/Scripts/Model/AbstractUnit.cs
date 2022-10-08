using UnityEngine;

namespace GB_Asteroids
{
    public abstract class AbstractUnit : IMove
    {
        private float _speed;

        public float Speed { get => _speed; set => _speed = value; }


        public void Move(Vector2 input) 
        {
            ChangePosotion(input);
            ChangeRotation(input);
        }

        protected abstract void ChangePosotion(Vector2 input);

        protected abstract void ChangeRotation(Vector2 input);
    }
}

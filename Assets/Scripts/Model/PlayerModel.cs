using UnityEngine;

namespace GB_Asteroids 
{
    public class PlayerModel : IMove
    {
        private Transform _transform;
        private float _speed;
        private float _hp;

        public float Speed { get => _speed; set => _speed = value; }
        public float Hp { get => _hp; set => _hp = value; }
        public Transform Transform { get => _transform; set => _transform = value; }

        private Vector3 _move;

        public PlayerModel(PlayerView view) 
        {
            Transform = view.transform;
            Speed = view.Speed;
            Hp = view.Hp;
        }

        public void Move(Vector2 input)
        {
            var deltaTime = Time.deltaTime;
            var speed = deltaTime * Speed;

            _move.Set(input.x * speed, input.y * speed, 0.0f);
            Transform.localPosition += _move;
        }
    }
}


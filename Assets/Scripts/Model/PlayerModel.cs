using UnityEngine;

namespace GB_Asteroids 
{
    public class PlayerModel : AbstractUnit
    {
        private Transform _transform;
        private float _pitchMult;
        private float _rollMult;

        private float _hp;

        public float Hp { get => _hp; set => _hp = value; }
        public Transform Transform { get => _transform; set => _transform = value; }
        public float PitchMult { get => _pitchMult; set => _pitchMult = value; }
        public float RollMult { get => _rollMult; set => _rollMult = value; }

        public PlayerModel(PlayerView view) 
        {
            Transform = view.transform;
            Speed = view.Speed;
            PitchMult = view.PitchMult;
            RollMult = view.RollMult;
            Hp = view.Hp;
        }

        protected override void ChangePosotion(Vector2 input)
        {
            float xAxis = input.x;
            float yAxis = input.y;

            var pos = Transform.position;
            pos.x += xAxis * Speed * Time.deltaTime;
            pos.y += yAxis * Speed * Time.deltaTime;
            Transform.position = pos;
        }

        protected override void ChangeRotation(Vector2 input)
        {
            float xAxis = input.x;
            float yAxis = input.y;

            Transform.rotation = Quaternion.Euler(yAxis * PitchMult, xAxis * RollMult, 0);
        }
    }
}


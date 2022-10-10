using UnityEngine;

namespace GB_Asteroids 
{
    public class PlayerModel : AbstractUnit
    {
        private Transform _transform;
        private float _rotationSpeed;

        private float _hp;

        public float Hp { get => _hp; set => _hp = value; }
        public Transform Transform { get => _transform; set => _transform = value; }
        public float RotationSpeed { get => _rotationSpeed; set => _rotationSpeed = value; }

        private IWeapon _weapon;
        private IEngine _engine;

        public PlayerModel(PlayerView view) 
        {
            Transform = view.transform;
            Speed = view.Speed;
            RotationSpeed = view.RotationSpeed;

            Hp = view.Hp;

            _weapon = new WeaponModel(view.Weapon);
            _engine = new EngineModel(view.Engine);
        }

        protected override void ChangePosotion(Vector2 input)
        {
            _engine.AddForce(Transform.up * input.y);
        }

        protected override void ChangeRotation(Vector2 input)
        {
            Transform.Rotate(Vector3.back * input.x * RotationSpeed * Time.deltaTime);
        }

        public void Shoot() => _weapon.Fire();
    }
}


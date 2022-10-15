using UnityEngine;

namespace GB_Asteroids 
{
    public class PlayerModel : AbstractUnit
    {
        private Transform _transform;      
        public Transform Transform { get => _transform; set => _transform = value; }
       
        public HealthModel Health { get; set; }
        
        private IWeapon _weapon;
        private IEngine _engine;
        private IRotation _rotator;

        public PlayerModel(PlayerView view) 
        {
            Transform = view.transform;
            Health = new HealthModel(view.Hp);

            _weapon = new WeaponModel(view.Weapon);
            _engine = new EngineModel(view.Engine);
            _rotator = new RotatorModel(view.Rotator, Transform);

        }

        protected override void ChangePosotion(Vector2 input)
        {
            _engine.AddForce(Transform.up * input.y);
        }

        protected override void ChangeRotation(Vector2 input)
        {
            _rotator.Rotate(Vector3.back * input.x);
        }

        public void Shoot() 
        { 
            _weapon.Fire();
        }

        public void TakeDamage(float amount)
        {
            Health.ChangeCurrentHp(Health.CurrentHealth - amount);
        }

    }
}


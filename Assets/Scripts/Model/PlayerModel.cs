using GB_Asteroids.Proxy;
using UnityEngine;

namespace GB_Asteroids
{
    public class PlayerModel : AbstractUnit
    {
        private Transform _transform;
        public Transform Transform { get => _transform; private set => _transform = value; }

        private Rigidbody _rigidbody;
        public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }

        public HealthModel Health { get; set; }

        private IEngine _engine;
        private IRotation _rotator;

        private IFire _fire;
        private IWeapon _weapon;
        private WeaponProxy _weaponProxy;
        private LockWeapon _lockWeapon = new LockWeapon();
        private bool _reloadState = true;
        private bool _laserSightState = false;

        public PlayerModel(PlayerView view)
        {
            Transform = view.transform;
            
            Rigidbody = view.Rigidbody;

            Health = new HealthModel(view.Hp);

            _weapon = new WeaponModel(view.Weapon);
            _engine = new EngineModel(view.Engine.Type, view.Engine.Power, view.Engine.ForceMode);
            _rotator = new RotatorModel(view.Rotator, Transform);

            _weaponProxy = new WeaponProxy(_weapon, _lockWeapon);

            _fire = _weaponProxy;

            _reloadState = true;
            _laserSightState = false;
        }

        protected override void ChangePosotion(Vector2 input)
        {
            _engine.MoveModel.Move(Rigidbody,Transform.up * input.y);
        }

        protected override void ChangeRotation(Vector2 input)
        {
            _rotator.Rotate(Vector3.back * input.x);
        }

        public void OnOfLaserSight()
        {
            if (!_laserSightState)
            {
                _weapon.ModificationWeapon.ApplyModification(_weapon);
                _fire = _weapon.ModificationWeapon;
                _laserSightState = true;
            }
            else
            {
                _weapon = _weapon.ModificationWeapon.RemoveModifiction(_weapon);
                _fire = _weaponProxy;
                _laserSightState = false;
            }
        }

        public void Reload()
        {
            if (_reloadState)
            {
                _lockWeapon.IsLock = true;
                _reloadState = false;
            }
            else
            {
                _lockWeapon.IsLock = false;
                _reloadState = true;
            }

        }

        public void Shoot()
        {
            _fire.Fire();
        }

        public void TakeDamage(float amount)
        {
            Health.ChangeCurrentHp(Health.CurrentHealth - amount);
        }

    }
}


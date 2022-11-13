using GB_Asteroids.Proxy;
using UnityEngine;

namespace GB_Asteroids
{
    public class PlayerModel : AbstractUnit
    {
        public HealthModel Health { get; set; }

        private IEngine _engine;
        private IRotation _rotator;
        private IWeapon _weapon;

        public IEngine Engine { get => _engine; set => _engine = value; }
        public IRotation Rotator { get => _rotator; set => _rotator = value; }
        public IWeapon Weapon { get => _weapon; set => _weapon = value; }

        private IFire _fire;
        
        private WeaponProxy _weaponProxy;
        private LockWeapon _lockWeapon = new LockWeapon();
        private bool _reloadState = true;
        private bool _laserSightState = false;

        public PlayerModel(PlayerView view)
        {         
            Health = new HealthModel(view.Hp);

            _weapon = new WeaponModel(view.Weapon);

            _weaponProxy = new WeaponProxy(_weapon, _lockWeapon);

            _fire = _weaponProxy;

            _reloadState = true;
            _laserSightState = false;
        }

        public override void Move(Rigidbody rigidbody, Vector3 input)
        {
            Engine.MoveModel.Move(rigidbody, input);
        }

        public override void Rotate(Rigidbody rigidbody, Vector3 input)
        {
            Rotator.Rotate(rigidbody, input);
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


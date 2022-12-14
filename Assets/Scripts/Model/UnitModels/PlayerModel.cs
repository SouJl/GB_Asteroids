using GB_Asteroids.Proxy;
using UnityEngine;

namespace GB_Asteroids
{
    public class PlayerModel : AbstractUnit
    {
        public HealthModel Health { get; set; }
        private UnitModifier _modifier;

        private IWeapon _weapon;

        public IWeapon Weapon { get => _weapon; set => _weapon = value; }
        public UnitModifier Modifier { get => _modifier; set => _modifier = value; }

        private IFire _fire;
        
        private WeaponProxy _weaponProxy;
        private LockWeapon _lockWeapon = new LockWeapon();
        private bool _reloadState = true;
        private bool _laserSightState = false;

        public PlayerModel(PlayerView view)
        {
            Transform = view.transform;
            RigidBody = view.Rigidbody;

            Health = new HealthModel(view.Hp);

            Modifier = new UnitModifier(this);

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


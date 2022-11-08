
using UnityEngine;

namespace GB_Asteroids.Proxy
{
    public class WeaponProxy: IFire
    {
        private readonly IWeapon _weapon;
        private readonly LockWeapon _lockWeapon;

        public WeaponProxy(IWeapon weapon, LockWeapon lockWeapon)
        {
            _weapon = weapon;
            _lockWeapon = lockWeapon;
        }

        public void Fire()
        {
            if (!_lockWeapon.IsLock)
            {
                _weapon.FireModel.Fire();
            }
            else
            {
                Debug.Log("Weapon is lock");
            }

        }
    }
}

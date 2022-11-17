using UnityEngine;

namespace GB_Asteroids.FireModels
{
    class AbilityFireModel : BaseFireModel
    {
        private IAbility _ability;

        public AbilityFireModel(SimpleObjectConfig bulletConfig, Transform firePoint, float force, IAbility ability) : base(bulletConfig, firePoint, force)
        {
            _ability = ability;
        }

        public override void Fire()
        {
            Debug.Log(_ability.ToString());
        }
    }
}

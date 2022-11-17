using System.Collections;
using System.Collections.Generic;

namespace GB_Asteroids
{
    public class EnemyAbilityHandler : IAbilityIterator<DamageType>
    {
        private List<IAbility> _ability;

        public EnemyAbilityHandler(List<IAbility> ability)
        {
            _ability = ability;
        }

        public IAbility this[int index] => _ability[index];
        
        public IAbility GetAbility()
        {
            return _ability[UnityEngine.Random.Range(0, _ability.Count)];
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _ability.Count; i++)
            {
                yield return _ability[i];
            }
        }

        public IEnumerable<IAbility> GetAbility(DamageType index)
        {
            foreach (IAbility ability in _ability)
            {
                if (ability.DamageType == index)
                {
                    yield return ability;
                }
            }
        }

    }
}

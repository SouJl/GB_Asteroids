using System.Collections;
using System.Collections.Generic;

namespace GB_Asteroids
{
    public interface IAbilityIterator<T>
    {
        IAbility this[int index] { get; }
        IAbility GetAbility();
        IEnumerator GetEnumerator();
        IEnumerable<IAbility> GetAbility(T index);
    }
}

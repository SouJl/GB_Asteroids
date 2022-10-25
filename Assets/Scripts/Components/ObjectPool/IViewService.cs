using UnityEngine;

namespace GB_Asteroids
{
    public interface IViewService
    {
        T Instantiate<T>(GameObject prefab);

        void Destroy(GameObject gameObject);
    }
}

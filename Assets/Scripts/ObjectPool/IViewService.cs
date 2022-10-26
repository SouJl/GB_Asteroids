using UnityEngine;

namespace GB_Asteroids
{
    public interface IViewService
    {
        T Instantiate<T>(GameObject prefab, Transform patent = null);

        void Destroy(GameObject gameObject);
    }
}

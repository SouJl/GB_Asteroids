using UnityEngine;

namespace GB_Asteroids
{
    public interface IViewService
    {
        T Instantiate<T>(GameObject prefab, Transform initPos = null);

        void Destroy(GameObject gameObject);
    }
}

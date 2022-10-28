using UnityEngine;

namespace GB_Asteroids
{
    public interface IViewService
    {
        T Instantiate<T>(Object prefab, Transform initPos = null);

        void Destroy(GameObject gameObject);
    }
}

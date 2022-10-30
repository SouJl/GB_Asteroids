using UnityEngine;

namespace GB_Asteroids
{
    public interface IViewService
    {
        T Instantiate<T>(GameObject prefab, Vector3 initPos);

        void Destroy(GameObject gameObject);
    }
}

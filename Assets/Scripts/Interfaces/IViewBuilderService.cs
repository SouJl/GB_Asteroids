using UnityEngine;

namespace GB_Asteroids
{
    public interface IViewBuilderService
    {
        T Instantiate<T>(SimpleObjectConfig config);

        void Destroy(GameObject gameObject);
    }
}

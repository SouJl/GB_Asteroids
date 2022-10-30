using UnityEngine;

namespace GB_Asteroids
{
    public interface IViewBuilderService
    {
        T Instantiate<T>(SimpleObjectConfig config, Transform initPos = null);

        void Destroy(GameObject gameObject);
    }
}

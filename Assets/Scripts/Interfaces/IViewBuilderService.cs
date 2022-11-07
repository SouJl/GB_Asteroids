using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    public interface IViewBuilderService
    {
        Dictionary<string, BuiderPool> ViewCashe { get; set; }

        T Instantiate<T>(SimpleObjectConfig config);

        void Destroy(GameObject gameObject);
    }
}

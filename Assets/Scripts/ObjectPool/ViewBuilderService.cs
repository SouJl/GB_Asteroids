using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    public class ViewBuilderService: IViewService
    {
        private readonly Dictionary<string, BuiderPool> _viewCashe;

        public ViewBuilderService(int capasity)
        {
            _viewCashe = new Dictionary<string, BuiderPool>(capasity);
        }

        public T Instantiate<T>(GameObject prefab, Transform parent = null)
        {
            if (!_viewCashe.TryGetValue(prefab.name, out BuiderPool viewPool))
            {
                viewPool = new BuiderPool(prefab, parent);
                _viewCashe[prefab.name] = viewPool;
            }

            if (viewPool.Pop().TryGetComponent(out T component))
            {
                return component;
            }

            throw new InvalidOperationException($"{typeof(T)} not found");
        }

        public void Destroy(GameObject gameObject)
        {
            _viewCashe[gameObject.name].Push(gameObject);
        }
    }
}

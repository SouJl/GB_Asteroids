using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GB_Asteroids
{
    public class ViewBuilderService: IViewService
    {
        private readonly Dictionary<string, BuiderPool> _viewCashe;

        public ViewBuilderService(int capasity)
        {
            _viewCashe = new Dictionary<string, BuiderPool>(capasity);
        }

        public T Instantiate<T>(Object prefab, Transform initPos = null)
        {
            var config  = prefab as SimpleObjectConfig;

            if (!_viewCashe.TryGetValue(config.Name, out BuiderPool viewPool))
            {
                viewPool = new BuiderPool(config, initPos);
                _viewCashe[config.Name] = viewPool;
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

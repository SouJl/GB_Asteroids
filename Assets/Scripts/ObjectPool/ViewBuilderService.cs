using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    public class ViewBuilderService: IViewBuilderService
    {
        private readonly Dictionary<string, BuiderPool> _viewCashe;

        public ViewBuilderService()
        {
            _viewCashe = new Dictionary<string, BuiderPool>();
        }

        public T Instantiate<T>(SimpleObjectConfig config, Transform initPos = null)
        {
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

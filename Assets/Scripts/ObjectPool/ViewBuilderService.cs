using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    public class ViewBuilderService: IViewBuilderService
    {
        private Dictionary<string, BuiderPool> viewCashe;

        public Dictionary<string, BuiderPool> ViewCashe { get => viewCashe;  set => viewCashe = value; }

        public ViewBuilderService()
        {
            ViewCashe = new Dictionary<string, BuiderPool>();
        }

        public T Instantiate<T>(SimpleObjectConfig config)
        {
            if (!ViewCashe.TryGetValue(config.Name, out BuiderPool viewPool))
            {
                viewPool = new BuiderPool(config);
                ViewCashe[config.Name] = viewPool;
            }

            if (viewPool.Pop().TryGetComponent(out T component))
            {
                return component;
            }

            throw new InvalidOperationException($"{typeof(T)} not found");
        }

        public void Destroy(GameObject gameObject)
        {
            ViewCashe[gameObject.name].Push(gameObject);
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    public class ViewService : IViewService
    {
        private readonly Dictionary<string, ObjectPool> _viewCashe; 


        public ViewService(int capasity) 
        {
            _viewCashe = new Dictionary<string, ObjectPool>(capasity);
        }

        public T Instantiate<T>(GameObject prefab, Transform parent = null)
        {
            if(!_viewCashe.TryGetValue(prefab.name, out ObjectPool viewPool)) 
            {
                viewPool = new ObjectPool(prefab, parent);
                _viewCashe[prefab.name] = viewPool;
            }

            if(viewPool.Pop().TryGetComponent(out T component)) 
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

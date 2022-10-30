using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    public class ViewService : IViewService
    {
        private readonly Dictionary<string, ObjectPool> _viewCashe; 


        public ViewService() 
        {
            _viewCashe = new Dictionary<string, ObjectPool>();
        }

        public T Instantiate<T>(GameObject prefab, Transform initPos = null)
        {
            if(!_viewCashe.TryGetValue(prefab.name, out ObjectPool viewPool)) 
            {
                viewPool = new ObjectPool(prefab, initPos);
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

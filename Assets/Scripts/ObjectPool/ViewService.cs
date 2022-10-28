using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GB_Asteroids
{
    public class ViewService : IViewService
    {
        private readonly Dictionary<string, ObjectPool> _viewCashe; 


        public ViewService(int capasity) 
        {
            _viewCashe = new Dictionary<string, ObjectPool>(capasity);
        }

        public T Instantiate<T>(Object prefab, Transform initPos = null)
        {
            if(!_viewCashe.TryGetValue(prefab.name, out ObjectPool viewPool)) 
            {
                viewPool = new ObjectPool(prefab as GameObject, initPos);
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

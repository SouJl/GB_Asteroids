using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GB_Asteroids
{
    public class ObjectPool : IDisposable
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;
        private readonly Transform _root;

        public ObjectPool(GameObject prefab)
        {
            _prefab = prefab;
            _root = new GameObject($"[{_prefab.name}]").transform;
        }

        public GameObject Pop()
        {
            GameObject go;
            if(_stack.Count == 0) 
            {
                go = Object.Instantiate(_prefab);

                go.name = _prefab.name;
            }
            else 
            {
                go = _stack.Pop();
            }
            go.SetActive(true);
            go.transform.SetParent(null);
            return go;
        }

        public void Push(GameObject go) 
        {
            _stack.Push(go);
            go.transform.SetParent(_root);
            go.SetActive(false);
        }

        public void Dispose()
        {
            foreach (var gameObject in _stack)
            {
                Object.Destroy(gameObject);
            }

            _stack.Clear();
        }
    }
}

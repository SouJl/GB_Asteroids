using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    public class BuiderPool :IDisposable
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;
        private readonly Transform _root;
        private readonly Transform _instancePosition;

        public BuiderPool(GameObject gameobject, Transform initPos = null)
        {
            _prefab = gameobject;
            _root = new GameObject($"[{_prefab.name}]").transform;
            if (initPos != null)
            {
                _instancePosition = initPos;
            }
        }

        public GameObject Pop()
        {
            GameObject go;
            if (_stack.Count == 0)
            {
                go = _prefab;
                go.transform.position = _instancePosition.position;
                go.transform.rotation = Quaternion.identity;
                go.name = _prefab.name;
            }
            else
            {
                go = _stack.Pop();
                go.transform.position = _instancePosition.position;
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
                UnityEngine.Object.Destroy(gameObject);
            }

            _stack.Clear();
        }
    }
}

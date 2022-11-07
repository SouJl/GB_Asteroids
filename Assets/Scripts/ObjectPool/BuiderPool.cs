using GB_Asteroids.Builder;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    [Serializable]
    public class BuiderPool :IDisposable
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();   
        private readonly SimpleObjectConfig _ojectConfig;

        private readonly Transform _root;

        public BuiderPool(SimpleObjectConfig objectConfig)
        {
            _ojectConfig = objectConfig;

            _root = new GameObject($"[{_ojectConfig.Name}]").transform;
        }

        public GameObject Pop()
        {
            GameObject go;
            if (_stack.Count == 0)
            {
                go = Build(_ojectConfig);
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

        private GameObject Build(SimpleObjectConfig config)
        {
            return new GameObjectBuilder()
                .Visual
                .Size(config.Size)
                .Name(config.Name)
                .Tag(config.Tag)
                .MeshFilter(config.Mesh)
                .MeshRenderer(config.Material)
                .Physics
                .Rigidbody(config.RigidProperies)
                .SphereCollider(1)
                .Script
                .BoundsCheck(false);
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

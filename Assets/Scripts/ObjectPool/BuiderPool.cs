using GB_Asteroids.Builder;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    public class BuiderPool :IDisposable
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();   
        private readonly SimpleObjectConfig _ojectConfig;

        private readonly Transform _root;

        private readonly Transform _instancePosition;

        public BuiderPool(SimpleObjectConfig objectConfig, Transform initPos = null)
        {
            _ojectConfig = objectConfig;

            _root = new GameObject($"[{_ojectConfig.Name}]").transform;
            
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
                go = Build(_ojectConfig);
                go.transform.position = _instancePosition.position;
                go.transform.rotation = Quaternion.identity;
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

        private GameObject Build(SimpleObjectConfig config)
        {
            return new GameObjectBuilder()
                .Visual
                .Size(config.Size)
                .Name(config.Name)
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

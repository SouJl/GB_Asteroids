using System;
using UnityEngine;

namespace GB_Asteroids
{
    [CreateAssetMenu(fileName = "SimpleObjectConfig", menuName = "ScriptableObjects/SimpleObjectConfig")]
    public class SimpleObjectConfig : ScriptableObject
    {
        public string Name;
        public float Size;

        [Header("Mesh Properties")]
        public Mesh Mesh;
        public Material Material;

        public RigidProperies RigidProperies;

    }

    [Serializable]
    public struct RigidProperies 
    {
        public float Mass;
        public float Drag;
        public float Angular;
        public bool UseGravity;
        public bool IsKinematic;
    }
}

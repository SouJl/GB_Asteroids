using UnityEngine;

namespace GB_Asteroids.Builder
{
    internal sealed class GameObjectVisualBuilder: GameObjectBuilder
    {
        public GameObjectVisualBuilder(GameObject gameObject) : base(gameObject) { }

        public GameObjectVisualBuilder Size(float size) 
        {
            _gameObject.transform.localScale = Vector3.one * size;
            return this;
        }

        public GameObjectVisualBuilder Name(string name)
        {
            _gameObject.name = name;
            return this;
        }

        public GameObjectVisualBuilder MeshFilter(Mesh mesh)
        {
            var component = GetOrAddComponent<MeshFilter>();
            component.mesh = mesh;
            return this;
        }

        public GameObjectVisualBuilder MeshRenderer(Material material) 
        {
            var component = GetOrAddComponent<MeshRenderer>();
            component.material = material;
            return this;
        }

        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _gameObject.GetComponent<T>();
            if (!result)
            {
                result = _gameObject.AddComponent<T>();
            }
            return result;
        }
    }
}

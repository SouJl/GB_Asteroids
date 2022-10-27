using UnityEngine;

namespace GB_Asteroids.Builder
{
    internal sealed class GameObjectPhysicsBuilder: GameObjectBuilder
    {
        public GameObjectPhysicsBuilder(GameObject gameObject) : base(gameObject) { }
        
        public GameObjectPhysicsBuilder SphereCollider(float radius)
        {
            var component = GetOrAddComponent<SphereCollider>();
            component.radius = radius;
            component.isTrigger = true;
            return this;
        }

        public GameObjectPhysicsBuilder BoxCollider()
        {
            GetOrAddComponent<BoxCollider>();
            return this;
        }

        public GameObjectPhysicsBuilder Rigidbody(RigidProperies rigid)
        {
            var component = GetOrAddComponent<Rigidbody>();
            component.mass = rigid.Mass;
            component.drag = rigid.Drag;
            component.angularDrag = rigid.Angular;
            component.useGravity = rigid.UseGravity;
            component.isKinematic = rigid.IsKinematic;
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

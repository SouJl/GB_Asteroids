using UnityEngine;

namespace GB_Asteroids.Builder
{
    internal sealed class GameObjectScriptBuilder: GameObjectBuilder
    {
        public GameObjectScriptBuilder(GameObject gameObject) : base(gameObject) { }


        public GameObjectScriptBuilder BoundsCheck(bool keepOnScreen) 
        {
            var component = GetOrAddComponent<BoundsCheck>();
            component.KeepOnScreen = keepOnScreen;
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

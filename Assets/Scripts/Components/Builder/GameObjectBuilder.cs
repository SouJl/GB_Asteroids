using UnityEngine;

namespace GB_Asteroids.Builder 
{
    internal class GameObjectBuilder
    {
        protected GameObject _gameObject;
        
        public GameObjectBuilder() => _gameObject = new GameObject();

        protected GameObjectBuilder(GameObject gameObject) => _gameObject = gameObject;

        public GameObjectVisualBuilder Visual => new GameObjectVisualBuilder(_gameObject);

        public GameObjectPhysicsBuilder Physics => new GameObjectPhysicsBuilder(_gameObject);

        public GameObjectScriptBuilder Script => new GameObjectScriptBuilder(_gameObject);

        public static implicit operator GameObject(GameObjectBuilder builder)
        {
            return builder._gameObject;
        }

    }
}


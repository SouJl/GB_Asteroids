using UnityEngine;

namespace GB_Asteroids
{
    public class EngineModel : IEngine
    {
        private MovementType _movementType;

        private float _power;
        private ForceMode _forceMode;
        private IMove _moveModel;

        public MovementType MovementType { get => _movementType; private set => _movementType = value; }

        public float Power { get => _power; set => _power = value; }
        public ForceMode ForceMode { get => _forceMode; set => _forceMode = value; }
        public IMove MoveModel { get => _moveModel; set => _moveModel = value; }

        private MovementFactory _factory;

        public EngineModel(MovementType movementType, float power, ForceMode forceMode) 
        {
            MovementType = movementType;
            Power = power;
            ForceMode = forceMode;

            _factory = new MovementFactory(Power, ForceMode);

            MoveModel = _factory.GetMovement(MovementType);
        }
    }
}

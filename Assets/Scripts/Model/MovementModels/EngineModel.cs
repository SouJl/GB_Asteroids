using GB_Asteroids.Movement;
using UnityEngine;

namespace GB_Asteroids
{
    public class EngineModel : IEngine
    {
        private MovementType _movementType;

        private float _power;
        private ForceMode _forceMode;
        private Rigidbody _rigidbody;
        private IMove _moveModel;

        public MovementType MovementType { get => _movementType; }

        public float Power { get => _power; set => _power = value; }
        public ForceMode ForceMode { get => _forceMode; set => _forceMode = value; }
        public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }
        public IMove MoveModel { get => _moveModel; set => _moveModel = value; }

        private MovementFactory _factory;

        public EngineModel(EngineView view) 
        {
            Power = view.Power;
            ForceMode = view.ForceMode;
            Rigidbody = view.Rigidbody;

            _factory = new MovementFactory(Rigidbody, Power, ForceMode);

            MoveModel = _factory.GetMovement(view.Type);
        }
    }
}

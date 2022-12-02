using GB_Asteroids.State;
using UnityEngine;

namespace GB_Asteroids
{
    public abstract class AbstractUnit 
    {
        public StateMachine MovementSM { get; set; }
        public IdleState Idle { get; set; }
        public MovingState Moving { get; set; }

        private Transform _transform;
        private Rigidbody _rigidBody;

        public Transform Transform { get => _transform; set => _transform = value; }
        public Rigidbody RigidBody { get => _rigidBody; set => _rigidBody = value; }

        private IEngine _engine;
        private IRotation _rotator;

        public IEngine Engine { get => _engine; set => _engine = value; }
        public IRotation Rotator { get => _rotator; set => _rotator = value; }

        public abstract void Move(Rigidbody rigidbody, Vector3 input);

        public abstract void Rotate(Rigidbody rigidbody, Vector3 input);
    }
}

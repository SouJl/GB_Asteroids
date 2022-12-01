using GB_Asteroids.State;
using UnityEngine;

namespace GB_Asteroids
{
    public abstract class AbstractUnit : IMove, IRotation
    {
        public StateMachine MovementSM { get; private set; }
        public IdleState Idle { get; private set; }
        public MovingState Moving { get; private set; }

        public abstract void Move(Rigidbody rigidbody, Vector3 input);

        public abstract void Rotate(Rigidbody rigidbody, Vector3 input);
    }
}

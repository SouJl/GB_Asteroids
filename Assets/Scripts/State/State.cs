
using UnityEngine.InputSystem;

namespace GB_Asteroids.State
{
    public abstract class State
    {
        protected AbstractUnit unit;
        protected StateMachine stateMachine;
        protected PlayerAction inputSystem;

        protected State(AbstractUnit unit, StateMachine stateMachine, PlayerAction inputSystem)
        {
            this.unit = unit;
            this.stateMachine = stateMachine;
            this.inputSystem = inputSystem;
        }

        public virtual void Enter() { }

        public virtual void Input() { }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() { }

        public virtual void Exit() { }
    }
}

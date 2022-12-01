
using UnityEngine;
using UnityEngine.InputSystem;

namespace GB_Asteroids.State
{
    public class MovingState : State
    {
        protected InputAction _move;
        protected InputAction _offEngine;

        private bool _isOffEngine;
        private Vector3 _input;

        public MovingState(AbstractUnit unit, StateMachine stateMachine, PlayerAction inputSystem) : base(unit, stateMachine, inputSystem)
        {
            _move = inputSystem.Player.Movement;
            _offEngine = inputSystem.Player.KeyEngine;
        }

        public override void Enter()
        {
            base.Enter();
            
            _move.Enable();
            _offEngine.Enable();
        }

        public override void Input()
        {
            base.Input();

            _input = _move.ReadValue<Vector2>();
            _isOffEngine = _offEngine.IsPressed();
          
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (_isOffEngine)
            {
                stateMachine.ChangeState(unit.Idle);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void Exit()
        {
            base.Exit();
            
            _move.Disable();
            _offEngine.Disable();
        }

    }
}

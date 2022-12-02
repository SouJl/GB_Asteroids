using UnityEngine;
using UnityEngine.InputSystem;

namespace GB_Asteroids.State
{
    public class IdleState : State
    {
        protected InputAction _startEngine;

        private bool _isStartEngine;

        public IdleState(AbstractUnit unit, StateMachine stateMachine, PlayerAction inputSystem) : base(unit, stateMachine, inputSystem)
        {
            _startEngine = inputSystem.Player.KeyEngine;
        }

        public override void Enter()
        {
            base.Enter();
            _startEngine.Enable();

            _isStartEngine = false;

            Debug.Log("Двигатель выключен");
        }

        public override void Input()
        {
            base.Input();
            _isStartEngine = _startEngine.IsPressed();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_isStartEngine)
            {
                stateMachine.ChangeState(unit.Moving);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _startEngine.Disable();
        }
    }
}

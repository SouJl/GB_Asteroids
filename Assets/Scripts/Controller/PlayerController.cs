using GB_Asteroids.State;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GB_Asteroids
{
    public class PlayerController : IExecute
    {
        private PlayerModel _playerModel;
        private PlayerView _playerView;


        PlayerAction _inputActions;

        private InputAction _fire;
        private InputAction _laserSight;
        private InputAction _reload;
        private InputAction _modifire;

        public PlayerModel Player { get => _playerModel; }

        public PlayerController(PlayerView view)
        {
            _inputActions = new PlayerAction();

            _playerView = view;
            _playerModel = new PlayerModel(_playerView)
            {
                Engine = new EngineModel(_playerView.Engine.Type, _playerView.Engine.Power, _playerView.Engine.ForceMode),
                Rotator = new RotatorModel(_playerView.Rotator.RotationSpeed)
            };

            SetStateMachine();

            SetModifire();

            SetActions();
        }

        public void Execute()
        {
            _playerModel.MovementSM.CurrentState.Input();
            _playerModel.MovementSM.CurrentState.LogicUpdate();
        }

        public void FixedExecute()
        {
            _playerModel.MovementSM.CurrentState.PhysicsUpdate();
        }

        private void SetStateMachine() 
        {
            _playerModel.MovementSM = new StateMachine();
            _playerModel.Moving = new MovingState(_playerModel, _playerModel.MovementSM, _inputActions);
            _playerModel.Idle = new IdleState(_playerModel, _playerModel.MovementSM, _inputActions);
            _playerModel.MovementSM.Initialize(_playerModel.Moving);
        }

        private void SetModifire() 
        {
            _playerModel.Modifier.Add(new SpeedModifier(_playerModel, 5));
            _playerModel.Modifier.Add(new AtackModifire(_playerModel, 5, 50));
            _playerModel.Modifier.Add(new HealthModifier(_playerModel, 10));
        }

        private void SetActions()
        {
            _fire = _inputActions.Player.Fire;
            _laserSight = _inputActions.Player.LaserSight;
            _reload = _inputActions.Player.Reload;
            _modifire = _inputActions.Player.Modifire;

            _fire.performed += _ => _playerModel.Shoot();
            _laserSight.performed += _ => _playerModel.OnOfLaserSight();
            _reload.performed += _ => _playerModel.Reload();
            _modifire.performed += _ => AddModifire();

            OnEnable();
        }


        private void AddModifire()
        {
            ModifireType modifire = (ModifireType)UnityEngine.Random.Range(0, 4);
            Debug.Log($"add {modifire} modifire");
            _playerModel.Modifier.Handle(modifire);
        }

        private void OnEnable()
        {
            _fire.Enable();
            _laserSight.Enable();
            _reload.Enable();
            _modifire.Enable();
        }

        private void OnDisable()
        {
            _fire.Disable();
            _laserSight.Disable();
            _reload.Disable();
            _modifire.Disable();
        }

        ~PlayerController() => OnDisable();
    }
}


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
        
        private InputAction _move;
        private InputAction _fire;
        private InputAction _laserSight;
        private InputAction _reload;
        private InputAction _shift;

        public PlayerModel Player { get => _playerModel; }

        public PlayerController(PlayerView view)
        {
            _playerView = view;
            _playerModel = new PlayerModel(_playerView);

            _playerModel.Engine = new EngineModel(_playerView.Engine.Type, _playerView.Engine.Power, _playerView.Engine.ForceMode);
            _playerModel.Rotator = new RotatorModel(_playerView.Rotator.RotationSpeed);

            _playerModel.Modifier.Add(new SpeedModifier(_playerModel, 5));

            SetActions();
        }

        public void Execute()
        {
            Vector3 inputVector = _move.ReadValue<Vector2>();
            ChangePosition(inputVector);
            ChangeRotation(inputVector);        
        }

        private void SetActions() 
        {
            _inputActions = new PlayerAction();

            _move = _inputActions.Player.Movement;
            _fire = _inputActions.Player.Fire;
            _laserSight = _inputActions.Player.LaserSight;
            _reload = _inputActions.Player.Reload;
            _shift = _inputActions.Player.Shift;

            _fire.performed += _ => _playerModel.Shoot();
            _laserSight.performed += _ => _playerModel.OnOfLaserSight();
            _reload.performed += _ => _playerModel.Reload();
            _shift.performed += _ => _playerModel.Modifier.Handle();

            OnEnable();
        }


        private void ChangePosition(Vector3 input) 
        {
            _playerModel.Move(_playerView.Rigidbody, _playerView.transform.up * input.y * _playerModel.Engine.Power);
        }

        private void ChangeRotation(Vector3 input) 
        {
            _playerModel.Rotate(_playerView.Rigidbody, Vector3.back * input.x);
        }

        private void OnEnable()
        {
            _move.Enable();
            _fire.Enable();
            _laserSight.Enable();
            _reload.Enable();
            _shift.Enable();
        }

        private void OnDisable()
        {
            _move.Disable();
            _fire.Disable();
            _laserSight.Disable();
            _reload.Disable();
            _shift.Disable();
        }

        ~PlayerController() => OnDisable();
    }
}


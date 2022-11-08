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

        public PlayerModel Player { get => _playerModel; }

        public PlayerController(PlayerView view)
        {
            _playerView = view;
            _playerModel = new PlayerModel(_playerView);

            _inputActions = new PlayerAction();

            _move = _inputActions.Player.Movement;
            _fire = _inputActions.Player.Fire;
            _laserSight = _inputActions.Player.LaserSight;

            _fire.performed += _ => _playerModel.Shoot();
            _laserSight.performed += _ => _playerModel.OnOfLaserSight();

            OnEnable();
        }

        public void Execute()
        {
            _playerModel.Move(_move.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            _move.Enable();
            _fire.Enable();
            _laserSight.Enable();
        }

        private void OnDisable()
        {
            _move.Disable();
            _fire.Disable();
            _laserSight.Disable();
        }

        ~PlayerController() => OnDisable();
    }
}


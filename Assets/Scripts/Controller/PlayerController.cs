using UnityEngine;
using UnityEngine.InputSystem;

namespace GB_Asteroids 
{
    public class PlayerController : IExecute
    {
        PlayerModel _playerModel;
     
        PlayerView _playerView;

        PlayerAction _inputActions;
        
        private InputAction _move;


        public PlayerController(PlayerView view)
        {
            _playerView = view;
            _playerModel = new PlayerModel(_playerView);

            _inputActions = new PlayerAction();

            _move = _inputActions.Player.Movement;
            
            OnEnable();
        }

        public void Execute()
        {
            _playerModel.Move(_move.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            _move.Enable();
        }

        private void OnDisable()
        {
            _move.Disable();
        }

        ~PlayerController() => OnDisable();
    }
}


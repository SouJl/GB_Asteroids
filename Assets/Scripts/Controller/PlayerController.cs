using UnityEngine;

namespace GB_Asteroids 
{
    public class PlayerController : IExecute
    {
        PlayerModel _playerModel;
     
        PlayerView _playerView;

        public PlayerController(PlayerView view)
        {
            _playerView = view;

            _playerModel = new PlayerModel(_playerView);
        }

        public void Execute()
        {
            _playerModel.Move(Vector3.zero);
        }
    }
}


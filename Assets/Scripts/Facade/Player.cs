

namespace GB_Asteroids.Facade
{
    public class Player: IGameComponent
    {
        private PlayerController _playerController;

        public Player(PlayerView playerView) 
        {
            _playerController = new PlayerController(playerView);
        }

        public IExecute GetController() => _playerController;
    }
}

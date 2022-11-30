using GB_Asteroids.UI;

namespace GB_Asteroids.Facade
{
    public class Enemies: IGameComponent
    {
        private EnemyController _enemyController;

        public Enemies(EnemySpawnerView spawnersView, PlayerView playerView, EnemyDestroyedLogView logView) 
        {
            _enemyController = new EnemyController(spawnersView, playerView.transform, logView);
        }

        public IExecute GetController() => _enemyController;
    }
}

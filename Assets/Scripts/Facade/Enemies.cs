namespace GB_Asteroids.Facade
{
    public class Enemies: IGameComponent
    {
        private EnemyController _enemyController;

        public Enemies(EnemySpawnerView spawnersView, PlayerView playerView) 
        {
            _enemyController = new EnemyController(spawnersView, playerView.transform);
        }

        public IExecute GetController() => _enemyController;
    }
}

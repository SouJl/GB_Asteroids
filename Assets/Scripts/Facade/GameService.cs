
namespace GB_Asteroids.Facade
{
    public class GameService 
    {
        private ListExecuteController _executeUpdate = new ListExecuteController();

        public void Start(PlayerView playerView, EnemySpawnerView enemySpawners, SerializavbleViewServise viewServise) 
        {
            var player = new Player(playerView);
            var enemies = new Enemies(enemySpawners, playerView);

            _executeUpdate.AddExecuteObject(player.GetController());
            _executeUpdate.AddExecuteObject(enemies.GetController());

            SetService(viewServise);
        }

        public void Work() 
        {
            while (_executeUpdate.MoveNext())
            {
                IExecute tmp = (IExecute)_executeUpdate.Current;
                tmp.Execute();
            }
            _executeUpdate.Reset();
        }

        public void End() { }


        private void SetService(SerializavbleViewServise viewServise) 
        {
            ServiceLocator.SetService<IViewService>(new ViewService());
            ServiceLocator.SetService(viewServise.viewBuilder);
        }
    }
}

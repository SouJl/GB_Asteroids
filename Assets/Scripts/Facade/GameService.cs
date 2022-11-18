
namespace GB_Asteroids.Facade
{
    public class GameService 
    {
        private ListExecuteController _executeUpdate = new ListExecuteController();

        public void Start(PlayerView playerView, EnemySpawnerView enemySpawners, SerializavbleViewServise viewServise, RecodView recodView) 
        {
            var player = new Player(playerView);
            var enemies = new Enemies(enemySpawners, playerView);
            var memento = new Memento(recodView);

            _executeUpdate.AddExecuteObject(player.GetController());
            _executeUpdate.AddExecuteObject(enemies.GetController());
            _executeUpdate.AddExecuteObject(memento.GetController());

            SetService(viewServise);
        }

        public void WorkUpdate() 
        {
            while (_executeUpdate.MoveNext())
            {
                IExecute tmp = (IExecute)_executeUpdate.Current;
                tmp.Execute();
            }
            _executeUpdate.Reset();
        }

        public void WorkFixed() 
        {
            while (_executeUpdate.MoveNext())
            {
                IExecute tmp = (IExecute)_executeUpdate.Current;
                tmp.FixedExecute();
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

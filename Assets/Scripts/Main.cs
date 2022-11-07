using GB_Asteroids.Builder;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GB_Asteroids 
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        
        [SerializeField] private EnemySpawnerView _enemySpawner;

        [SerializeField] private SerializavbleViewServise serializavbleViewService;

        private ListExecuteController _executeUpdate;

        private PlayerController _playerController;
        private EnemyController _enemyController;



        void Start()
        {
            _executeUpdate = new ListExecuteController();

            _playerController = new PlayerController(_playerView);
            _playerController.Player.Health.EndOfHpAction += GameOver;
            _executeUpdate.AddExecuteObject(_playerController);

            _enemyController = new EnemyController(_enemySpawner, _playerView.transform);
            _executeUpdate.AddExecuteObject(_enemyController);

            ServiceLocator.SetService<IViewService>(new ViewService());
            ServiceLocator.SetService(serializavbleViewService.viewBuilder);
        }

        void Update()
        {
            while (_executeUpdate.MoveNext())
            {
                IExecute tmp = (IExecute)_executeUpdate.Current;
                tmp.Execute();
            }
            _executeUpdate.Reset();
        }

        private void GameOver(bool state)
        {
            if(!state)
                SceneManager.LoadScene("MainScene");
        }
    }
}


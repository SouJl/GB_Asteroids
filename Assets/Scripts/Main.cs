using GB_Asteroids.Facade;
using GB_Asteroids.UI;
using UnityEngine;

namespace GB_Asteroids 
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        
        [SerializeField] private EnemySpawnerView _enemySpawner;

        [SerializeField] private SerializavbleViewServise _serializavbleViewService;

        [SerializeField] private RecodView _recodView;

        [SerializeField] private EnemyDestroyedLogView _logView;

        private GameService game = new GameService();

        void Start()
        {
            game.Start(_playerView, _enemySpawner, _logView, _serializavbleViewService, _recodView);
        }

        void Update()
        {
            game.WorkUpdate();
        }

        private void FixedUpdate()
        {
            game.WorkFixed();
        }
    }
}


using GB_Asteroids.Facade;
using UnityEngine;

namespace GB_Asteroids 
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        
        [SerializeField] private EnemySpawnerView _enemySpawner;

        [SerializeField] private SerializavbleViewServise serializavbleViewService;


        private GameService game = new GameService();

        void Start()
        {
            game.Start(_playerView, _enemySpawner, serializavbleViewService);
        }

        void Update()
        {
            game.Work();
        }
    }
}


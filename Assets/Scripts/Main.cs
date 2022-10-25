using UnityEngine;
using UnityEngine.SceneManagement;

namespace GB_Asteroids 
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        
        [SerializeField] private EnemySpawnerView _enemySpawner;

        private PlayerController _playerController;
        private EnemyController _enemyController;


        void Start()
        {
            _playerController = new PlayerController(_playerView);
            _playerController.Player.Health.EndOfHpAction += GameOver;

            _enemyController = new EnemyController(_enemySpawner);
        }

        void Update()
        {
            _playerController.Execute();
            _enemyController.Execute();
        }

        private void GameOver(bool state)
        {
            if(!state)
                SceneManager.LoadScene("MainScene");
        }
    }
}


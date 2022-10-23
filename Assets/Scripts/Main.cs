using UnityEngine;
using UnityEngine.SceneManagement;

namespace GB_Asteroids 
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        
        [SerializeField] private EnemyFactory _enemyFactory;

        private PlayerController _playerController;

        void Start()
        {
            _playerController = new PlayerController(_playerView);
            _playerController.Player.Health.EndOfHpAction += GameOver;

            _enemyFactory.CreateEnemy(EnemyType.Asteroid);
            _enemyFactory.CreateEnemy(EnemyType.EnemyShip);
        }

        void Update()
        {
            _playerController.Execute();
        }

        private void GameOver(bool state)
        {
            if(!state)
                SceneManager.LoadScene("MainScene");
        }
    }
}


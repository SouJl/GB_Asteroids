using UnityEngine;
using UnityEngine.SceneManagement;

namespace GB_Asteroids 
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;

        private PlayerController _playerController;

        void Start()
        {
            _playerController = new PlayerController(_playerView);

            _playerController.Player.Health.EndOfHpAction += GameOver;
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


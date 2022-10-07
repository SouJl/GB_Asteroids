using UnityEngine;

namespace GB_Asteroids 
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;

        private PlayerController _playerController;

        void Start()
        {
            _playerController = new PlayerController(_playerView);
        }

        void Update()
        {
            _playerController.Execute();
        }
    }
}


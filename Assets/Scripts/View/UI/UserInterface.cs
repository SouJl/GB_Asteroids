using UnityEngine;
using UnityEngine.InputSystem;

namespace GB_Asteroids.UI
{
    public sealed class UserInterface : MonoBehaviour
    {
        [SerializeField] private PauseMenuUI _pauseMenu;
        [SerializeField] private UserHudUI _userHud;

        private BaseUI _currentUi;

        private StateUI _stateUi;

        private PlayerAction actions;
        private InputAction _pause;

        private void Start()
        {
            actions = new PlayerAction();
            
            _pause = actions.UI.Pause;
            _pause.performed += _ => OpenPauseMenu();

            _pause.Enable();

            Execute(StateUI.UserHud);
        }

        private void Execute(StateUI stateUI)
        {
            if (_currentUi != null)
            {
                _currentUi.Cancel();
            }

            switch (stateUI)
            {
                case StateUI.UserHud:
                    {
                        _currentUi = _userHud;
                        _stateUi = StateUI.UserHud;
                        break;
                    }
                case StateUI.PauseMenu:
                    {
                        _currentUi = _pauseMenu;
                        _stateUi = StateUI.PauseMenu;
                    }
                    break;
                default:
                    break;
            }

            _currentUi.Execute();
        }

        private void OpenPauseMenu() 
        {
            switch (_stateUi)
            {
                case StateUI.UserHud:
                    {
                        Execute(StateUI.PauseMenu);
                        break;
                    }
                case StateUI.PauseMenu:
                    {
                        Execute(StateUI.UserHud);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

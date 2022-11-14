using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GB_Asteroids.UI
{
    public class PauseMenuUI : BaseUI
    {

        [SerializeField] private TextMeshProUGUI _panelText;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _optionsButton;
        [SerializeField] private Button _quitButton;

        public Button ResumeButton { get => _resumeButton; }
        public Button OptionsButton { get => _optionsButton;}
        public Button QuitButton { get => _quitButton;}

        public override void Execute()
        {
            Time.timeScale = 0f;
            gameObject.SetActive(true);
        }

        public override void Cancel()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }       
    }
}

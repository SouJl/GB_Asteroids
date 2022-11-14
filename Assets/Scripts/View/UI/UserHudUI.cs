using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GB_Asteroids.UI
{
    public class UserHudUI : BaseUI
    {
        [SerializeField] private TextMeshProUGUI _scoreText;


        public override void Execute()
        {
            _scoreText.text = "Score: 000";
            gameObject.SetActive(true);
        }

        public override void Cancel()
        {
            gameObject.SetActive(false);
        }      
    }
}

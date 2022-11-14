using System;
using TMPro;
using UnityEngine;

namespace GB_Asteroids.UI
{
    public class UserHudUI : BaseUI
    {
        [SerializeField] private TextMeshProUGUI _scoreText;


        private void Update()
        {
            Interpret("Score");
        }

        public override void Execute()
        {
            gameObject.SetActive(true);
        }

        public override void Cancel()
        {
            gameObject.SetActive(false);
        }

        private void Interpret(string value)
        {
            switch (value) 
            {
                case "Score": 
                    {
                        _scoreText.text = $"Score: {ScoreFormat(StaticMembers.Score)}";
                        break;
                    }
            }
        }

        private string ScoreFormat(float score) 
        {
            if (score < 0) return "0";
            if (score >= 10000000) return "10M";

            if (score < 1000) return score.ToString();
            if (score >= 1000 && score < 10000) return $"{(int)(score / 1000)}K";
            if (score >= 10000 && score < 1000000) return $"{(int)(score / 1000)}k";
            if (score >= 1000000) return $"{(int)(score / 1000000)}M";

            throw new ArgumentOutOfRangeException(nameof(score));
        } 
    }
}

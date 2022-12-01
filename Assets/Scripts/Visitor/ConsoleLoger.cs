using GB_Asteroids.Enemy;
using UnityEngine;

namespace GB_Asteroids.Visitor
{
    public sealed class ConsoleLoger : IGameLog
    {
        public void Log(AsteroidModel source, string info, LoggerType logType)
        {
            string message = $"{nameof(AsteroidModel)} - {info}";
            ShowLog(message, logType);
        }

        public void Log(EnemyShipModel source, string info, LoggerType logType)
        {
            string message = $"{nameof(EnemyShipModel)} - {info}";
            ShowLog(message, logType);
        }

        public void Log(PlayerModel source, string info, LoggerType logType)
        {
            string message = $"{nameof(PlayerModel)} - {info}";
            ShowLog(message, logType);
        }

        private void ShowLog(string message, LoggerType type) 
        {
            switch (type) 
            {
                case LoggerType.Info: 
                    {
                        Debug.Log(message);
                        break;
                    }
                case LoggerType.Warning: 
                    {
                        Debug.LogWarning(message);
                        break;
                    }
                case LoggerType.Eror: 
                    {
                        Debug.LogError(message);
                        break;
                    }
            }
        }
    }
}

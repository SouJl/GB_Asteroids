using GB_Asteroids.Enemy;

namespace GB_Asteroids.Visitor
{
    public interface IGameLog
    {
        void Log(AsteroidModel source, string info, LoggerType logType);
        void Log(EnemyShipModel source, string info, LoggerType logType);
        void Log(PlayerModel source, string info, LoggerType logType);
    }
}

using System;

namespace GB_Asteroids
{
    public class EnemyController : IExecute
    {
        IEnemyFactory EnemyFactory;

        public EnemyController(IEnemyFactory enemyFactory) 
        {
            EnemyFactory = enemyFactory;

            EnemyFactory.CreateEnemy(EnemyType.Asteroid);
            EnemyFactory.CreateEnemy(EnemyType.Asteroid);
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}

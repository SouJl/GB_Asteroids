using GB_Asteroids.Enemy;
using UnityEngine;

namespace GB_Asteroids
{
    public class EnemyFactory : MonoBehaviour, IEnemyFactory
    {
        [SerializeField] private GameObject _asteroid;
        
        [SerializeField] private GameObject _enemyShip;

        [SerializeField] private Vector3 _startPosition;

        private Vector3 _offset = Vector3.zero;
      
        public IEnemy CreateEnemy(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Asteroid:
                    {
                        Instantiate(_asteroid, _startPosition + _offset, Quaternion.identity);
                        _offset = new Vector3(Random.Range(-10, 10), 0, 0);
                        return new AsteroidModel();
                    }
                case EnemyType.EnemyShip:
                    {
                        Instantiate(_enemyShip, _startPosition + _offset, Quaternion.identity);
                        _offset = new Vector3(Random.Range(-10, 10), 0, 0);
                        return new EnemyShipModel();
                    }
                default:
                    return null;
            }
        }
    }
}

using GB_Asteroids.Enemy;
using UnityEngine;

namespace GB_Asteroids
{
    public class EnemyFactory : MonoBehaviour, IEnemyFactory
    {
        [SerializeField] private EnemyConfig _asteroid, _enemyShip;

        [SerializeField] private Vector3 _startPosition;

        private Vector3 _offset = Vector3.zero;
      
        public IEnemy CreateEnemy(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Asteroid:
                    {
                        Vector3 spawnDir = Random.insideUnitSphere.normalized * 10;
                        var obj = Instantiate(_asteroid.Prefab, spawnDir, Quaternion.identity);
                        var view = obj.GetComponent<EnemyView>();
                        AsteroidModel asteroidModel = new AsteroidModel(_asteroid, view.Transform);
                        view.Interact += asteroidModel.Interaction;
                        obj.GetComponent<Rigidbody>().AddForce(Quaternion.identity * -spawnDir);
                        return asteroidModel;
                    }
                case EnemyType.EnemyShip:
                    {
                        var obj = Instantiate(_enemyShip.Prefab, _startPosition + _offset, Quaternion.identity);
                        _offset = new Vector3(Random.Range(-10, 10), 0, 0);
                        return new EnemyShipModel(_enemyShip, obj.transform);
                    }
                default:
                    return null;
            }
        }
    }
}

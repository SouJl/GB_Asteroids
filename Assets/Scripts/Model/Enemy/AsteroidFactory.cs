using GB_Asteroids.Enemy;
using UnityEngine;

namespace GB_Asteroids
{
    [CreateAssetMenu(fileName = "AsteroidFactory", menuName = "ScriptableObjects/AsteroidFactory")]
    public class AsteroidFactory : EnemyFactory
    {
        public override IEnemy Create(Vector3 position, Quaternion rotation)
        {
            var obj = Instantiate(Config.Prefab, position, rotation);
            AsteroidModel asteroidModel = new AsteroidModel(Config, obj.GetComponent<EnemyView>());

            return asteroidModel;
        }
    }
}

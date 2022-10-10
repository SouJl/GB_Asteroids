using UnityEngine;
using Object = UnityEngine.Object;

namespace GB_Asteroids
{
    public class ProcessesSingleton : MonoBehaviour
    {
        public static ProcessesSingleton Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public T SpawnObject<T>(T obj, Vector3 pos) where T : Object
        {
            return Instantiate(obj, pos, Quaternion.identity);
        }
    }
}

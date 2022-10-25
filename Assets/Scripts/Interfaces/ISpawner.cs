
using UnityEngine;

namespace GB_Asteroids
{
    interface ISpawner
    {
        float TimeBeforeSpawn { get; set; }

        void Spawn();

        Vector3 GetPosition();

        Quaternion GetRotation();
    }
}

using UnityEngine;

namespace GB_Asteroids
{
    public interface IEngine
    {
        float Power { get; set; }
        ForceMode ForceMode { get; set; }
        Rigidbody Rigidbody { get; set; }

        void AddForce(Vector3 direction);
    }
}

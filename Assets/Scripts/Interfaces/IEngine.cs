using UnityEngine;

namespace GB_Asteroids
{
    public interface IEngine
    {
        MovementType MovementType { get;}

        float Power { get; set; }
        ForceMode ForceMode { get; set; }
        Rigidbody Rigidbody { get; set; }

        IMove MoveModel { get; set; }
    }
}

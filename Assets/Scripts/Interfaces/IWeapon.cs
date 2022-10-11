using UnityEngine;

namespace GB_Asteroids
{
    public interface IWeapon
    {
        float FireForce { get; set; }
        int FireRate { get; set; }

        Transform FirePoint { get; set; }

        void Fire();
    }
}

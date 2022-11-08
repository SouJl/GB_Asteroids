using UnityEngine;

namespace GB_Asteroids
{
    public class LaserDotModficationWepon : ModificationWeapon
    {
        public Transform LaserDotPosition { get; }
        public GameObject LaserDotPrefab { get; }

        public LaserDotModficationWepon(Transform laserDotPosition, GameObject laserDotPrefab) 
        {
            LaserDotPosition = laserDotPosition;
            LaserDotPrefab = laserDotPrefab;
        }

        protected override IWeapon AddModification(IWeapon weapon)
        {
            GameObject laserDot = Object.Instantiate(LaserDotPrefab, LaserDotPosition.position, Quaternion.identity);
            return weapon;
        }
    }
}

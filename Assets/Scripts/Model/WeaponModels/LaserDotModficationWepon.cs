using UnityEngine;

namespace GB_Asteroids
{
    public class LaserDotModficationWepon : ModificationWeapon
    {
        public Transform LaserDotPosition { get; }
        public GameObject LaserDotPrefab { get; }

        private GameObject _laserSight;

        public LaserDotModficationWepon(Transform laserDotPosition, GameObject laserDotPrefab) 
        {
            LaserDotPosition = laserDotPosition;
            LaserDotPrefab = laserDotPrefab;
        }

        protected override IWeapon AddModification(IWeapon weapon)
        {
            _laserSight = Object.Instantiate(LaserDotPrefab, LaserDotPosition.position, LaserDotPosition.rotation);

            _laserSight.transform.SetParent(LaserDotPosition);

            return weapon;
        }

        public override IWeapon RemoveModifiction(IWeapon weapon)
        {
            _laserSight.transform.SetParent(null);
            Object.Destroy(_laserSight);
            return weapon;
        }
    }
}

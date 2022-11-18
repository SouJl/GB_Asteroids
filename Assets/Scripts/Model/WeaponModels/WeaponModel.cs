namespace GB_Asteroids
{
    public class WeaponModel : IWeapon
    {
        private int _fireRate;
        private float _damage;
        private FireType _fireType;
        private IFire _fireModel;

        public int FireRate { get => _fireRate; set => _fireRate = value; }
        public FireType FireType { get => _fireType; set => _fireType = value; }
        public IFire FireModel { get => _fireModel; set => _fireModel = value; }
        public ModificationWeapon ModificationWeapon { get; private set; }
        public float Damage { get => _damage; set => _damage = value; }

        private FireFactory _factory;

        public WeaponModel(WeaponView view) 
        {
            FireRate = view.FireRate;
            Damage = view.Damage;
            FireType = view.FireType;
            _factory = new FireFactory(view.BulletConfig, view.FirePoint, view.FireForce);
            FireModel = _factory.GetFireModel(FireType);

            ModificationWeapon = new LaserDotModficationWepon(view.LaserSightPosition, view.LaserSightPrefab);
        }  
    }
}

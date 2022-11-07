namespace GB_Asteroids
{
    public class WeaponModel : IWeapon
    {
        private int _fireRate;
        private FireType _fireType;
        private IFire _fireModel;

        public int FireRate { get => _fireRate; set => _fireRate = value; }
        public FireType FireType { get => _fireType; set => _fireType = value; }
        public IFire FireModel { get => _fireModel; set => _fireModel = value; }

        private FireFactory _factory;

        public WeaponModel(WeaponView view) 
        {
            FireRate = view.FireRate;
            FireType = view.FireType;
            _factory = new FireFactory(view.BulletConfig, view.FirePoint, view.FireForce);
            FireModel = _factory.GetFireModel(FireType);
        }  
    }
}

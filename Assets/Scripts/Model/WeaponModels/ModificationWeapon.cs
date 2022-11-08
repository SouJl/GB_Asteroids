namespace GB_Asteroids
{
    public abstract class ModificationWeapon : IFire
    {
        private IWeapon _weapon;

        protected abstract IWeapon AddModification(IWeapon weapon);
   
        public void ApplyModification(IWeapon weapon) 
        {
            _weapon = AddModification(weapon);
        }

        public abstract IWeapon RemoveModifiction(IWeapon weapon);

        public void Fire()
        {
            _weapon.FireModel.Fire();
        }
    }
}

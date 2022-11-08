namespace GB_Asteroids
{
    public interface IWeapon
    {
        int FireRate { get; set; }

        FireType FireType { get; set; }

        IFire FireModel { get; set; }

        ModificationWeapon ModificationWeapon { get;}
    }
}

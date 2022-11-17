namespace GB_Asteroids
{
    public class Ability : IAbility
    {
        public string Name { get; }
        public int Damage { get; }
        public DamageType DamageType { get; }
         

        public Ability(string name, int damage, DamageType damageType)
        {
            Name = name;
            DamageType = damageType;
            Damage = damage;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

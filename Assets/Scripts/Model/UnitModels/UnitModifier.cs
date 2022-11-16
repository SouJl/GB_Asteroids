
namespace GB_Asteroids
{
    public class UnitModifier
    {
        protected PlayerModel player;
        protected UnitModifier Next;

        public UnitModifier(PlayerModel player) 
        {
            this.player = player;
        }

        public void Add(UnitModifier unit) 
        {
            if (Next != null)
            {
                Next.Add(unit);
            }
            else 
            {
                Next = unit;
            }
        }

        public virtual void Handle() => Next?.Handle();
    }
}

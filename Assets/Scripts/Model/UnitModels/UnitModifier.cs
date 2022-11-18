
namespace GB_Asteroids
{
    public class UnitModifier
    {
        protected PlayerModel player;
        protected UnitModifier Next;

        protected virtual ModifireType Type { get; }

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

        public virtual void Handle(ModifireType type) => Next?.Handle(type);
    }
}

using UnityEngine;

namespace GB_Asteroids
{
    public class HealthModifier : UnitModifier
    {
        private float _health;

        protected override ModifireType Type => ModifireType.Healh;

        public HealthModifier(PlayerModel player, float health) : base(player)
        {
            _health = health;
        }

        public override void Handle(ModifireType type)
        {
            if(type == Type) 
            {
                player.Health.ChangeCurrentHp(player.Health.CurrentHealth + _health);
                Debug.Log($"Player restore {_health} hp. Current healh: {player.Health.CurrentHealth}");
            }
            else
                base.Handle(type);
        }
    }
}

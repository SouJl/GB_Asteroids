using UnityEngine;

namespace GB_Asteroids
{
    public class SpeedModifier : UnitModifier
    {
        private float _maxSpeed;

        protected override ModifireType Type => ModifireType.Speed;

        public SpeedModifier(PlayerModel player, float maxSpeed) : base(player)
        {
            _maxSpeed = maxSpeed;
        }

        public override void Handle(ModifireType type)
        {
            if(type == Type) 
            {
                if(player.Engine.Power < _maxSpeed) 
                {
                    player.Engine.Power ++;
                }
                Debug.Log($"Player increase speed by one. Current speed: {player.Engine.Power}");
            }
            else
                base.Handle(type);
        }
    }
}

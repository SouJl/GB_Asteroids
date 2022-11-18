using UnityEngine;

namespace GB_Asteroids
{
    public class AtackModifire: UnitModifier
    {
        private float _addAtack;
        private float _maxAtack;

        protected override ModifireType Type => ModifireType.Atack;

        public AtackModifire(PlayerModel player, float addAtack, float maxAtack) : base(player)
        {
            _addAtack = addAtack;
            _maxAtack = maxAtack;
        }


        public override void Handle(ModifireType type)
        {
            if (type == Type) 
            {
                if(player.Weapon.Damage < _maxAtack) 
                {
                    player.Weapon.Damage += _addAtack;
                    Debug.Log($"Player increase atack by {_addAtack}. Current atack: {player.Weapon.Damage}");
                }
            }
            else
                base.Handle(type);
        }
    }
}

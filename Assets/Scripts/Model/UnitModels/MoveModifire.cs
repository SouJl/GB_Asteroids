using UnityEngine;

namespace GB_Asteroids
{
    public class MoveModifire : UnitModifier
    {
        private Rigidbody _rigidbody;

        private Vector3 _direction;

        public MoveModifire(PlayerModel player, Rigidbody rigidbody, Vector3 direction) : base(player)
        {
            _rigidbody = rigidbody;
            _direction = direction;
        }

        public override void Handle()
        {
            player.Engine.MoveModel.Move(_rigidbody, _direction);
            base.Handle();
        }
    }
}

namespace GB_Asteroids
{
    public class SpeedModifier : UnitModifier
    {
        private float _speed;

        public SpeedModifier(PlayerModel player, float speed) : base(player)
        {
            _speed = speed;
        }

        public override void Handle()
        {
            player.Engine.Power += _speed;
            base.Handle();
        }
    }
}

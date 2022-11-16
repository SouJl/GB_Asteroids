namespace GB_Asteroids
{
    public class HealthModifier : UnitModifier
    {
        private float _health;

        public HealthModifier(PlayerModel player, float health) : base(player)
        {
            _health = health;
        }

        public override void Handle()
        {
            player.Health.ChangeCurrentHp(player.Health.CurrentHealth + _health);

            base.Handle();
        }
    }
}

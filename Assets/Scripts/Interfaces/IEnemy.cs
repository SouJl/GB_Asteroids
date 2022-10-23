
namespace GB_Asteroids
{
    public interface IEnemy
    {
        HealthModel Health { get; set; }

        void DealDamage();

        void TakeDamage(float amount);
    }
}

using UnityEngine;

namespace GB_Asteroids
{
    public class EnemyModel : AbstractUnit
    {
        private Transform _transform;

        public Transform Transform { get => _transform; set => _transform = value; }

        protected HealthModel Health { get; set; }

        public EnemyModel(Transform transform, float maxHeath) 
        {
            Transform = transform;
            Health = new HealthModel(maxHeath);
        }

        protected override void ChangePosotion(Vector2 input)
        {
            
        }

        protected override void ChangeRotation(Vector2 input)
        {
            
        }
    }
}

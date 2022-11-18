using GB_Asteroids.MessageBroker;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace GB_Asteroids.Enemy
{
    public class AsteroidModel : AbstractEnemy
    {
        private float _size;
        private float _minSize;

        public float Size { get => _size; set => _size = value; }
        public float MinSize { get => _minSize;}

        public AsteroidModel(AsteroidView view) : base(view) 
        {
            Size = view.Size;
            _minSize = view.MinSize;
            Health.EndOfHpAction += Split;

            MessageBrokerHandler.Instance.Subscribe(this, OnDefatMessage);
        }

        public AsteroidModel(EnemyConfig config, EnemyView view):base(config, view) 
        {
            Health.EndOfHpAction += Split;            
        }

        public AsteroidModel(AsteroidModel source) : base(source) 
        {
            _minSize = source.MinSize;
            Health.EndOfHpAction += Split;

            MessageBrokerHandler.Instance.Subscribe(this, OnDefatMessage);
        }
        
        public override void SetTrajectory(Vector3 direction)
        {
            Rigidbody.AddForce(direction * 10);
        }

        public override void DealDamage(IFire fire)
        {
            
        }

        public override void TakeDamage(float amount)
        {
            Health.ChangeCurrentHp(Health.CurrentHealth - amount);
        }

        public override void Interaction(Collider collider)
        {
            base.Interaction(collider);
        }


        public override IEnemy Clone() => new AsteroidModel(this);


        public void Split(bool state) 
        {
            if ((Size * 0.5f) >= MinSize)
            {
                for (int i = 0; i < 2; i++)
                {
                    var newAsteroid = CreateSplit(this);

                    newAsteroid.SetTrajectory(Random.insideUnitCircle.normalized * 20);
                }
            }
            
            StaticMembers.Score += Points;

            Object.Destroy(View.gameObject);

            MessageBrokerHandler.Instance.Publish(this);
            MessageBrokerHandler.Instance.Unsubscribe(this, OnDefatMessage);
        }

        private IEnemy CreateSplit(AsteroidModel model) 
        {
            float newSize = model.Size * 0.5f;

            Vector2 position = model.Transform.position;
            position += Random.insideUnitCircle.normalized * 0.5f;

            var halfAsteroid = model.Clone() as AsteroidModel;

            halfAsteroid.View.Transform.position = position;
            halfAsteroid.View.Transform.localScale = Vector3.one * newSize;

            halfAsteroid.Size = newSize;

            return halfAsteroid;
        }

        private void OnDefatMessage() => Debug.Log($"{Name} Defeat");
    }
}

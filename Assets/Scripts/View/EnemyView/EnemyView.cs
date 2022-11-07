using System;
using UnityEngine;

namespace GB_Asteroids
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyView: BaseView
    {

        [SerializeField] private Rigidbody _rigidBody;

        [SerializeField] private EnemyType _type;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _damage;
        [SerializeField] private float _points;

        [SerializeField] private BoundsCheck _boundsCheck;

        public Rigidbody RigidBody { get => _rigidBody; set => _rigidBody = value; }

        public EnemyType Type { get => _type; set => _type = value; }
        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public float Damage { get => _damage; set => _damage = value; }
        public float Points { get => _points; set => _points = value; }

        public event Action<Collider> Interact;

        private int _cloneCount = 0;

        protected override void Awake()
        {
            base.Awake();
            RigidBody = GetComponent<Rigidbody>();
            
        }

        private void Start()
        {
            _boundsCheck = GetComponent<BoundsCheck>();
        }

        private void Update()
        {
            if (!_boundsCheck) return;

            if (_boundsCheck.IsOutOfBounds())
            {
                OutOfBounds();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Interact?.Invoke(other);
        }

        public void OutOfBounds() 
        {
            Defeat(false);
        }

        public void Defeat(bool state)
        {
            Destroy(gameObject);
            //ServiceLocator.Resolve<IViewService>().Destroy(gameObject);
        }


        public EnemyView Clone() 
        {
            _cloneCount += 1;

            var newObject = new GameObject($"{name}");

            newObject.tag = tag;

            if (gameObject.TryGetComponent<MeshFilter>(out var meshFilter)) 
            {
                var newMeshFilter = newObject.AddComponent<MeshFilter>();
                newMeshFilter.mesh = meshFilter.mesh;
            }

            if (gameObject.TryGetComponent<MeshRenderer>(out var meshRenderer))
            {
                var newMeshRenderer = newObject.AddComponent<MeshRenderer>();
                newMeshRenderer.material = meshRenderer.material;
            }

            if (gameObject.TryGetComponent<Rigidbody>(out var rigidbody))
            {
                var newRigidbody = newObject.AddComponent<Rigidbody>();
                newRigidbody.mass = rigidbody.mass;
                newRigidbody.drag = rigidbody.drag;
                newRigidbody.angularDrag = rigidbody.angularDrag;
                newRigidbody.useGravity = rigidbody.useGravity;
                newRigidbody.isKinematic = rigidbody.isKinematic;

                /*newRigidbody.velocity = rigidbody.velocity;*/
                newRigidbody.angularVelocity = rigidbody.angularVelocity;

                newRigidbody.constraints = rigidbody.constraints;
            }

            if (gameObject.TryGetComponent<SphereCollider>(out var sphereCollider))
            {
                var newSphereCollider = newObject.AddComponent<SphereCollider>();
                newSphereCollider.radius = sphereCollider.radius;
                newSphereCollider.isTrigger = sphereCollider.isTrigger;
            }

            if(gameObject.TryGetComponent<BoundsCheck>(out var boundsCheck)) 
            {
                var newBoundsCheck = newObject.AddComponent<BoundsCheck>();
                newBoundsCheck.KeepOnScreen = boundsCheck.KeepOnScreen;
            }

            newObject.transform.position = transform.position;

            return newObject.AddComponent<EnemyView>();
        }
    }
}

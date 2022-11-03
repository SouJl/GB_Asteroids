using UnityEngine;

namespace GB_Asteroids
{
    public class AsteroidView: EnemyView
    {
        [SerializeField] private float _size;
        [SerializeField] private float maxSize;

        public float Size { get => _size; set => _size = value; }
        
        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            transform.localScale = Vector3.one * Size;
        }
    }
}

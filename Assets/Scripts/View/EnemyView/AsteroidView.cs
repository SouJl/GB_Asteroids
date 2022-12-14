using UnityEngine;

namespace GB_Asteroids
{
    public class AsteroidView: EnemyView
    {
        [SerializeField] private float _size;
        
        private float _minSize;

        public float Size { get => _size; set => _size = value; }
        public float MinSize { get => _minSize; set => _minSize = value; }

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

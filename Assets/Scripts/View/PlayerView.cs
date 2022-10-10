using UnityEngine;

namespace GB_Asteroids 
{
    [RequireComponent(typeof(EngineView))]
    public class PlayerView : MonoBehaviour
    {
        [Header("Movement settings")]
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed = 20f;

        [SerializeField] private float _hp;

        private EngineView _engine;
        private WeaponView _weapon;

        public float Speed { get => _speed; set => _speed = value; }
        public float RotationSpeed { get => _rotationSpeed; set => _rotationSpeed = value; }
        public float Hp { get => _hp; set => _hp = value; }
        public WeaponView Weapon { get => _weapon; set => _weapon = value; }
        public EngineView Engine { get => _engine; set => _engine = value; }

        private void Awake()
        {
            Weapon = GetComponent<WeaponView>();
            Engine = GetComponent<EngineView>();
        }
    }
}


using UnityEngine;

namespace GB_Asteroids 
{
    [RequireComponent(typeof(EngineView), typeof(RotatorView))]
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private float _hp = 150f;

        private EngineView _engine;
        private WeaponView _weapon;
        private RotatorView _rotator;

        public float Hp { get => _hp; set => _hp = value; }
        
        public WeaponView Weapon { get => _weapon; private set => _weapon = value; }
        public EngineView Engine { get => _engine; private set => _engine = value; }
        public RotatorView Rotator { get => _rotator; private set => _rotator = value; }

        private void Awake()
        {
            Weapon = GetComponent<WeaponView>();
            Engine = GetComponent<EngineView>();
            Rotator = GetComponent<RotatorView>();
        }
    }
}


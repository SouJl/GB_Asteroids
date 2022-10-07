using UnityEngine;

namespace GB_Asteroids 
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _hp;

        public float Speed { get => _speed; set => _speed = value; }
        public float Hp { get => _hp; set => _hp = value; }
    }
}


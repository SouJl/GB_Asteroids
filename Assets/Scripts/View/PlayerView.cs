using UnityEngine;

namespace GB_Asteroids 
{
    public class PlayerView : MonoBehaviour
    {
        [Header("Movement settings")]
        [SerializeField] private float _speed;
        [SerializeField] private float _pitchMult = 30f;
        [SerializeField] private float _rollMult = -45f;

        [SerializeField] private float _hp;

        public float Speed { get => _speed; set => _speed = value; }
        public float Hp { get => _hp; set => _hp = value; }
        public float PitchMult { get => _pitchMult; set => _pitchMult = value; }
        public float RollMult { get => _rollMult; set => _rollMult = value; }
    }
}


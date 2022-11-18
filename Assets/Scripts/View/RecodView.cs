using UnityEngine;

namespace GB_Asteroids
{
    public class RecodView : MonoBehaviour
    {
        [SerializeField] private float _recordTime = 5f;
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Rigidbody _targetRigidBody;

        public float RecordTime { get => _recordTime; set => _recordTime = value; }
        public Transform TargetTransform { get => _targetTransform; set => _targetTransform = value; }
        public Rigidbody TargetRigidBody { get => _targetRigidBody; set => _targetRigidBody = value; }
    }
}

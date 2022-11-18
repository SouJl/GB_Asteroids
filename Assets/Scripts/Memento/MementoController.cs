using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GB_Asteroids.Memento
{
    public class MementoController:IExecute
    {
        private float _recordTime;
        private Transform _transform;
        private Rigidbody _rigidBody;
        private bool _isRewinding;

        private List<PointInTime> _pointsInTime;

        PlayerAction _inputActions;

        private InputAction _record;

        public MementoController(float recordTime, Transform transform, Rigidbody rigidBody) 
        {
            _recordTime = recordTime;
            _transform = transform;
            _rigidBody = rigidBody;

            _pointsInTime = new List<PointInTime>();

            _inputActions = new PlayerAction();
            _record = _inputActions.Player.Record;

            _isRewinding = false;
            OnEnable();

        }

        public void Execute()
        {
            if (_record.WasPressedThisFrame()) 
            {
                StartRewind();
                Debug.Log("Is record");
            }
            if(_record.WasReleasedThisFrame())
            {
                StopRewind();
                Debug.Log("Is no record");
            }
        }

        public void FixedExecute()
        {
            if (_isRewinding)
            {
                Rewind();
            }
            else
            {
                Record();
            }
        }

        private void Rewind()
        {
            if (_pointsInTime.Count > 1)
            {
                PointInTime pointInTime = _pointsInTime[0];
                _transform.position = pointInTime.Position;
                _transform.rotation = pointInTime.Rotation;
                _pointsInTime.RemoveAt(0);
            }
            else
            {
                PointInTime pointInTime = _pointsInTime[0];
                _transform.position = pointInTime.Position;
                _transform.rotation = pointInTime.Rotation;
                StopRewind();
            }
        }
        private void Record()
        {
            if (_pointsInTime.Count > Mathf.Round(_recordTime /
            Time.fixedDeltaTime))
            {
                _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
            }
            _pointsInTime.Insert(0, new PointInTime(_transform.position, _transform.rotation, _rigidBody.velocity, _rigidBody.angularVelocity));
        }

        private void StartRewind()
        {
            _isRewinding = true;
        }

        private void StopRewind()
        {
            _isRewinding = false;
            _rigidBody.velocity = _pointsInTime[0].Velocity;
            _rigidBody.angularVelocity = _pointsInTime[0].AngularVelocity;
        }

        private void OnEnable()
        {
            _record.Enable();
        }

        private void OnDisable()
        {
            _record.Disable();
        }

   

        ~MementoController() => OnDisable();

    }
}

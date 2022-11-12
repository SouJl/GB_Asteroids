using GB_Asteroids.Movement;
using UnityEngine;

namespace GB_Asteroids
{
    public class MovementFactory
    {
        private float _power;
        private ForceMode _mode;

        public MovementFactory(float power, ForceMode mode) 
        {
            _power = power;
            _mode = mode;
        }

        public IMove GetMovement(MovementType type) 
        {
            switch (type)
            {
                default:
                    return null;

                case MovementType.Force:
                    {
                        return new ForceMoveModel(_power, _mode);
                    }
                case MovementType.Dash:
                    {
                        return new DashMoveModel(_power, _mode);
                    }
            }
        }

    }
}

using UnityEngine;

namespace GB_Asteroids.UI 
{
    public abstract class BaseUI : MonoBehaviour
    {
        public abstract void Execute();
        public abstract void Cancel();
    }
}


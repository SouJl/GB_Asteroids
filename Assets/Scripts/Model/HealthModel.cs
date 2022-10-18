using System;
using UnityEngine;

namespace GB_Asteroids 
{
    public class HealthModel
    {
        private float _maxHealth;
        private float _currentHealth;
        
        public float MaxHealth { get => _maxHealth; }

        public float CurrentHealth 
        { 
            get => _currentHealth;
            private set 
            {
                if(_currentHealth != value) 
                {
                    _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
                   
                    if(_currentHealth == 0) EndOfHpAction?.Invoke(false);
                }
            }
        }

        public Action<bool> EndOfHpAction  = delegate (bool state) { };

        public HealthModel(float maxHealth) 
        {
            _maxHealth = maxHealth;
            CurrentHealth = _maxHealth;
        }

        public void ChangeCurrentHp(float amount)
        {
            CurrentHealth = amount;              
        }
    }
}

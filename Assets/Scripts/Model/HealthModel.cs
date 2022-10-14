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
                   
                    Debug.Log(CurrentHealth);
                }
            }
        }

        public Action<bool> EndOfHpAction { get; set; }

        public HealthModel(float maxHealth) 
        {
            _maxHealth = maxHealth;
            CurrentHealth = _maxHealth;
        }

        public void ChangeCurrentHp(float amount)
        {
            CurrentHealth = amount;

            if (CurrentHealth <= 0)
                EndOfHpAction?.Invoke(false);
        }
    }
}

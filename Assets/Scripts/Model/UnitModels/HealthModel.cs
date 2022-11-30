using System;
using UnityEngine;

namespace GB_Asteroids 
{
    public class HealthModel
    {
        private float _maxHealth;
        private float _currentHealth;
        private string _name;

        public float MaxHealth { get => _maxHealth; }

        public float CurrentHealth 
        { 
            get => _currentHealth;
            private set 
            {
                if(_currentHealth != value) 
                {
                    _currentHealth = Mathf.Clamp(value, 0, MaxHealth);

                    if (_currentHealth == 0)
                    {
                        EndOfHpAction?.Invoke(false);
                        OnEndHealth?.Invoke(_name);
                    }
                }
            }
        }

        public Action<bool> EndOfHpAction;
        public Action<string> OnEndHealth;

        public HealthModel(float maxHealth) 
        {
            _maxHealth = maxHealth;
            CurrentHealth = _maxHealth;
        }

        public HealthModel(float maxHealth, string name)
        {
            _maxHealth = maxHealth;
            CurrentHealth = _maxHealth;
            _name = name;
        }

        public void ChangeCurrentHp(float amount)
        {
            CurrentHealth = amount;              
        }
    }
}

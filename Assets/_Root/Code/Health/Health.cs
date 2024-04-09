using _Root.Code.Input;
using UnityEngine;

namespace _Root.Code.Health
{
    public class Health
    {
        private float MaxHealth;
        private float CurrentHealth;
        private GameObject _gameObject; 

        public Health(float maxHealth, float currentHealth, GameObject gameObject)
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            _gameObject = gameObject;
        }

        public void AddHealth(float health)
        {
            CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + health);
        }

        public void GetDamage(float damage)
        {
            CurrentHealth = Mathf.Max(0, CurrentHealth - damage);

            if (CurrentHealth == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _gameObject.SetActive(false);
        }
    }
}
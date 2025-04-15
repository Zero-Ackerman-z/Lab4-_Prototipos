using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerStats : MonoBehaviour
    {

        [SerializeField] private int maxHealth = 10;
        [SerializeField] private int currentHealth;
        [SerializeField] private int score;

        private void Start()
        {
            currentHealth = maxHealth;
            GameEvents.OnMaxHealthSet?.Invoke(maxHealth);
            GameEvents.OnHealthChanged?.Invoke(currentHealth);
            GameEvents.OnScoreChanged?.Invoke(score);
        }

        public void ModifyHealth(int amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            GameEvents.OnHealthChanged?.Invoke(currentHealth);
            if (currentHealth <= 0) GameEvents.OnPlayerDeath?.Invoke();
        }

        public void AddScore(int amount)
        {
            score += amount;
            GameEvents.OnScoreChanged?.Invoke(score);
        }
    }
}

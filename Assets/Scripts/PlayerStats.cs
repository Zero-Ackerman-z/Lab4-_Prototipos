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
            GameEvents.RaiseMaxHealthSet(maxHealth);
            GameEvents.RaiseHealthChanged(currentHealth);
            GameEvents.RaiseScoreChanged(score);
        }

        public void ModifyHealth(int amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            GameEvents.RaiseHealthChanged(currentHealth);
            if (currentHealth <= 0) GameEvents.RaisePlayerDeath();
        }

        public void AddScore(int amount)
        {
            score += amount;
            GameEvents.RaiseScoreChanged(score);
        }
    }
}

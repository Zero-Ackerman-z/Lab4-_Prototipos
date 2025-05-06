using Assets.GameEvents;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerStats : MonoBehaviour
    {

        [Header("Game Events")]
        [SerializeField] private IntGameEvent onMaxHealthSetEvent;
        [SerializeField] private IntGameEvent onHealthChangedEvent;
        [SerializeField] private IntGameEvent onScoreChangedEvent;
        [SerializeField] private GameEvent onPlayerDeathEvent;

        [SerializeField] private int maxHealth = 10;
        [SerializeField] private int currentHealth;
        [SerializeField] private int score;

        private void Start()
        {
            currentHealth = maxHealth;
            onMaxHealthSetEvent?.Raise(maxHealth);
            onHealthChangedEvent?.Raise(currentHealth);
            onScoreChangedEvent?.Raise(score);
            //GameEvents.RaiseMaxHealthSet(maxHealth);
            //GameEvents.RaiseHealthChanged(currentHealth);
            //GameEvents.RaiseScoreChanged(score);
        }

        public void ModifyHealth(int amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            //GameEvents.RaiseHealthChanged(currentHealth);
            onHealthChangedEvent?.Raise(currentHealth);
            if (currentHealth <= 0) GameEvents.RaisePlayerDeath();
        }

        public void AddScore(int amount)
        {
            score += amount;
            onScoreChangedEvent?.Raise(score);

            //GameEvents.RaiseScoreChanged(score);
        }
    }
}

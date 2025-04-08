using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        GameEvents.TriggerHealthChanged(currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0);
        GameEvents.TriggerHealthChanged(currentHealth);
        if (currentHealth == 0)
            GameEvents.TriggerGameOver();
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        GameEvents.TriggerHealthChanged(currentHealth);
    }
}


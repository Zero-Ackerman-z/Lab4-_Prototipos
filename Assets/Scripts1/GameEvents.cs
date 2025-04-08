using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GameEvents
{
    
    public delegate void OnHealthChanged(int currentHealth);
    public static event OnHealthChanged HealthChanged;

    public delegate void OnScoreChanged(int currentScore);
    public static event OnScoreChanged ScoreChanged;

    public delegate void OnGameOver();
    public static event OnGameOver GameOver;

    public delegate void OnVictory();
    public static event OnVictory Victory;

    public static void TriggerHealthChanged(int value) => HealthChanged?.Invoke(value);
    public static void TriggerScoreChanged(int value) => ScoreChanged?.Invoke(value);
    public static void TriggerGameOver() => GameOver?.Invoke();
    public static void TriggerVictory() => Victory?.Invoke();
}

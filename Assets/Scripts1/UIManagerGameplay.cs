using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerGameplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    private int currentScore = 0;

    private void OnEnable()
    {
        GameEvents.ScoreChanged += UpdateScore;
        GameEvents.HealthChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        GameEvents.ScoreChanged -= UpdateScore;
        GameEvents.HealthChanged -= UpdateHealth;
    }

    void UpdateScore(int score)
    {
        currentScore += score;
        scoreText.text = $"Puntos: {currentScore}";
    }

    void UpdateHealth(int health)
    {
        healthText.text = $"Vida: {health}";
    }
}

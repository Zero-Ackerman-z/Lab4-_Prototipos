using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private Slider healthSlider;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI timerText;

        private float timer;
        private float targetHealth;
        private int maxHealth = 100;

        private void OnEnable()
        {
            GameEvents.OnHealthChanged += UpdateHealth;
            GameEvents.OnMaxHealthSet += SetMaxHealth;
            GameEvents.OnScoreChanged += UpdateScore;
        }

        private void OnDisable()
        {
            GameEvents.OnHealthChanged -= UpdateHealth;
            GameEvents.OnMaxHealthSet -= SetMaxHealth;
            GameEvents.OnScoreChanged -= UpdateScore;
        }
        private void Update()
        {
            timer += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(timer);
            timerText.text = time.ToString("mm\\:ss");

            healthSlider.value = Mathf.Lerp(healthSlider.value, targetHealth, Time.deltaTime * 10f);

        }
        private void SetMaxHealth(int max)
        {
            maxHealth = max;
            healthSlider.maxValue = 1f;
            targetHealth = 1f; 
            healthSlider.value = 1f;
        }
        private void UpdateHealth(int value)
        {
            Debug.Log($"Vida actual: {value}");
            if (maxHealth <= 0) return; 
            targetHealth = (float)value / maxHealth;
        }

        private void UpdateScore(int value)
        {
            scoreText.text = $"Score: {value}";
        }
    }
}

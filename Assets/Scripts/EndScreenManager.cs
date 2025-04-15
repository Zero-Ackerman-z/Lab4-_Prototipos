using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
namespace Assets.Scripts
{
    public class EndScreenManager : MonoBehaviour
    {
        [SerializeField] private GameObject ResultPanel;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private TextMeshProUGUI timeText;

        private void OnEnable()
        {
            GameEvents.OnPlayerDeath += ShowLose;
            GameEvents.OnPlayerWin += ShowWin;
        }

        private void OnDisable()
        {
            GameEvents.OnPlayerDeath -= ShowLose;
            GameEvents.OnPlayerWin -= ShowWin;
        }
        
        private void ShowLose()
        {
            ResultPanel.SetActive(true);
            Time.timeScale = 0f;
            losePanel.SetActive(true);
            UpdateTime();
        }
        private void ShowWin()
        {
            ResultPanel.SetActive(true);

            Time.timeScale = 0f;
            winPanel.SetActive(true);
            UpdateTime();
        }

        private void UpdateTime()
        {
            float time = Time.timeSinceLevelLoad;
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            timeText.text = timeSpan.ToString("mm\\:ss");
        }

        public void Retry()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void GoToMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Home"); 
        }
      
    }

}
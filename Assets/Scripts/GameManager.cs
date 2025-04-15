using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {

        private bool isPaused = false;
        private int totalCoins;
        private int collectedCoins;

        private void Start()
        {
            totalCoins = FindObjectsOfType<Coin>().Length;
        }
        public void CoinCollected()
        {
            collectedCoins++;
            if (collectedCoins >= totalCoins)
            {
                GameEvents.RaisePlayerWin();
            }
        }
        public void TogglePause()
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f;
        }
    }
}
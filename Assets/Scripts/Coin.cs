using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Coin : MonoBehaviour, ICollectable
    {
        [SerializeField] private int points = 10;
        private GameManager gameManager;

        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        public void Collect(PlayerStats stats)
        {
            stats.AddScore(points);
            gameManager.CoinCollected();
            Destroy(gameObject);
        }
    }

}
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Obstacle : MonoBehaviour
    {
        public PlayerColor color;
        [SerializeField] private int damage = 1;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerController player))
            {
                Debug.Log("Colisión detectada");
                if (!player.IsObstacleSameColor(this)) 
                    player.TakeDamage(damage);
            }
        }
    }
}
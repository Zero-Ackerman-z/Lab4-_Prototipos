using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Heart : MonoBehaviour, ICollectable
    {
        [SerializeField] private int healAmount = 2;

        public void Collect(PlayerStats stats)
        {
            stats.ModifyHealth(healAmount);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts
{
    public class ColorButton : MonoBehaviour
    {

        [SerializeField] private PlayerColor colorToSet;
        [SerializeField] private PlayerController player;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(ChangeColor);
        }
        private void ChangeColor()
        {
            player.ChangeColor(colorToSet);
        }
    }
}
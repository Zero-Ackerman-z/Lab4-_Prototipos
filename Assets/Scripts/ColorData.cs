using Assets.Scripts;
using UnityEngine;
public enum PlayerColor
{
    Red,
    Blue,
    Green
}
[CreateAssetMenu(fileName = "ColorData", menuName = "ScriptableObjects/ColorData")]
public class ColorData : ScriptableObject
{
    public PlayerColor playerColor;
    public Color unityColor;
}
//public interface IDamageable1
//{
//    void TakeDamage(int amount);
//}
////public interface ICollectable1
//{
//    void Collect(PlayerStats stats);
//}
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
public interface IDamageable
{
    void TakeDamage(int amount);
}
public interface ICollectable
{
    void Collect(PlayerStats stats);
}
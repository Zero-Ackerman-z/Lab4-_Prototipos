using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Score Event", menuName = "Game Events/Score Event")]
public class ScoreEvent : ScriptableObject
{
    private System.Action<int> listeners;

    public void Raise(int score)
    {
        listeners?.Invoke(score);
    }

    public void RegisterListener(System.Action<int> listener)
    {
        listeners += listener;
    }

    public void UnregisterListener(System.Action<int> listener)
    {
        listeners -= listener;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreEventListener : MonoBehaviour
{
    [SerializeField] private ScoreEvent scoreEvent;
    [SerializeField] private UnityEvent<int> response;

    private void OnEnable()
    {
        if (scoreEvent != null)
        {
            scoreEvent.RegisterListener(OnEventRaised);
        }
    }

    private void OnDisable()
    {
        if (scoreEvent != null)
        {
            scoreEvent.UnregisterListener(OnEventRaised);
        }
    }

    public void OnEventRaised(int score)
    {
        response?.Invoke(score);
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.GameEvents
{

    [CreateAssetMenu(menuName = "Game Events/Int Event")]
    public class IntGameEvent : ScriptableObject
    {
        private List<IntGameEventListener> listeners = new List<IntGameEventListener>();

        public void Raise(int value)
        {
            foreach (var listener in listeners)
            {
                listener.OnEventRaised(value);
            }
        }

        public void RegisterListener(IntGameEventListener listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void UnregisterListener(IntGameEventListener listener)
        {
            if (listeners.Contains(listener))
                listeners.Remove(listener);
        }
    }
}



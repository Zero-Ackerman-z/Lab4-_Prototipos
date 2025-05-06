using UnityEngine;
using System.Collections;
using Assets.GameEvents;
using UnityEngine.Events;
namespace Assets.GameEvents
{
    [System.Serializable]
    public class IntUnityEvent : UnityEvent<int> { }

    public class IntGameEventListener : MonoBehaviour
    {
        [SerializeField] private IntGameEvent gameEvent;
        [SerializeField] private IntUnityEvent response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(int value)
        {
            response.Invoke(value);
        }
    }
}

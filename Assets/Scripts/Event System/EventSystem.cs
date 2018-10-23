using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class EventSystem : MonoBehaviour
    {

        private static EventSystem _Current;
        public static EventSystem Current
        {
            get
            {
                if (_Current == null)
                {
                    _Current = GameObject.FindObjectOfType<EventSystem>();
                }
                return _Current;
            }
        }

        public delegate void EventListener();
        Dictionary<EVENT_TYPE, List<EventListener>> eventListeners;

        public void RegisterListener(EVENT_TYPE eventType, EventListener listener)
        {
            if (eventListeners == null)
            {
                eventListeners = new Dictionary<EVENT_TYPE, List<EventListener>>();
            }

            if (!eventListeners.ContainsKey(eventType) || eventListeners[eventType] == null)
            {
                eventListeners[eventType] = new List<EventListener>();
            }

            eventListeners[eventType].Add(listener);
        }

        public void UnregisterListener(EVENT_TYPE eventType, EventListener listener)
        {
            eventListeners[eventType].Remove(listener);
        }

        public void FireEvent(EVENT_TYPE eventType)
        {
            if (eventListeners[eventType] == null) { return; }
            foreach (EventListener eventListener in eventListeners[eventType])
            {
                eventListener();
            }
        }
    } 
}

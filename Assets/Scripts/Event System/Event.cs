﻿using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    [CreateAssetMenu(menuName = "Rocket/Event")]
    public class Event : ScriptableObject
    {
        List<Listener> eventListeners = new List<Listener>();

        public void RegisterListener(Listener listener)
        {
            if (!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(Listener listener)
        {
            if (eventListeners.Contains(listener))
            {
                eventListeners.Remove(listener);
            }
        }

        public void Raise()
        {
            foreach(Listener listener in eventListeners)
            {
                listener.OnEventRaised();
            }
        }

    } 
}

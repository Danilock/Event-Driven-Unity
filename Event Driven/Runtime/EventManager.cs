using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EventDriven
{
    public static class EventManager
    {
        private static Dictionary<object, List<object>> EventsRegister = new Dictionary<object, List<object>>();

        public static void TriggerEvent<T>(T eventToTrigger) where T : struct
        {
            if (EventsRegister.ContainsKey(eventToTrigger))
            {
                foreach (var listener in EventsRegister[eventToTrigger])
                {
                    var currentListener = (IEventListener<T>) listener;
                    currentListener.OnTriggerEvent(new T());
                }
            }
        }

        public static void AddListener<T>(T eventToListen, IEventListener<T> listener) where T : struct
        {
            if (EventsRegister.ContainsKey(eventToListen))
            {
                EventsRegister[eventToListen].Add(listener);
                return;
            }

            EventsRegister.Add(eventToListen, new List<object> {listener});
        }

        public static void RemoveListener<T>(T eventToListen, IEventListener<T> listener) where T : struct
        {
            if (EventsRegister.ContainsKey(eventToListen))
                EventsRegister[eventToListen].Remove(listener);
        }
    }

    public enum GameEventsTypes
    {
        LevelStart,
        LevelEnd
    }

    public struct GameEvent
    {
        public GameEventsTypes EventTypes;

        public GameEvent(GameEventsTypes eventsTypes)
        {
            EventTypes = eventsTypes;
        }
    }
}
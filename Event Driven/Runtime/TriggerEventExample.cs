using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventDriven
{
    public class TriggerEventExample : MonoBehaviour, IEventListener<GameEvent>
    {
        private void OnEnable()
        {
            this.StartListening<GameEvent>();
        }

        private void OnDisable()
        {
            this.StopListening<GameEvent>();
        }

        public void OnTriggerEvent(GameEvent data)
        {
            Debug.Log(data.EventTypes);
        }

        [ContextMenu("TriggerEvent")]
        public void TriggerEvent()
        {
            EventManager.TriggerEvent(new GameEvent(GameEventsTypes.LevelStart));
        }
    }
}
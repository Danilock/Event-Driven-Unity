# Event-Driven-Unity
Use this plugin to create events in Unity using interfaces as a listener.

## IEventListener<T>
This interface will allow the specific class to listen to an event.
 
```c#
 public class TestListener : MonoBehavior, IEventListener<GameEvent>
 {
      private void OnEnable(){
          //Start listening to this event once the object is enabled.
          this.StartListening<GameEvent>();
      }

      private void OnDisable(){
          //Stop listening to this event once the object is disabled.
          this.StopListening<GameEvent>();
      }
 
      public void OnTriggerEvent(GameEvent data)
      {
            if(data.EventType == GameEventsTypes.LevelStart)
               //Some code once the level is started.
      }
 }
```

 I recommend you to start/stop listening to events in the **OnEnable** and **OnDisable** **UnityMethods** respectively.
 
 In this example we're making this moobehaviour to listen to a GameEvent event. You can create whichever type of event you want, we recommend using the [EventList.cs](https://github.com/Danilock/Event-Driven-Unity/blob/main/Event%20Driven%20System/EventList.cs) but you can create the event wherever you want.
 
 #Example of an event
 **IMPORTANT**: Game events have to be structures.
 
 ```c#
 using UnityEngine;

 public enum GameEventsTypes { LevelStart, GameOver, Pause, Resume }
 
 public struct GameEvent
 {
      public GameEventsTypes EventType;
      
      public GameEvent(GameEventsTypes type){
          EventType = type;
      }
 }
 ```
 
 #Triggering the Event
 By this moment, we have our event and our listener... but, we have to trigger that event.
 
 To trigger an event just call EventManager.TriggerEvent() from any class.
 
 For example, we can have a GameManager and trigger the event once the level is loaded.
 
 ```c#
 public class GameManager : MonoBehavior
 {
      public void LevelStarted(){
         EventManager.TriggerEvent(new GameEvent(GameEventsTypes.LevelStart));
      }
 }
 ```
 
 

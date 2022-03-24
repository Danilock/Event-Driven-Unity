# Event-Driven-Unity
Use this plugin to create events in Unity using interfaces as a listener.

## IEventListener<T>
This interface will allow the specific class to listen to an event.
 
```c#
 public class TestListener : MonoBehavior, IEventListener<GameEvent>
 {
      private void OnEnable(){
          this.StartListening<GameEvent>();
      }
 
      private void OnDisable(){
          this.StartListening<GameEvent>();
      }
 }
```

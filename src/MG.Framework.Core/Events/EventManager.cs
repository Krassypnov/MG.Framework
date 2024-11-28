using MG.Framework.Core.Game;

namespace MG.Framework.Core.Events;

public class EventManager
{
    public List<Event> Events { get; private set; } = new();
    
    public void AddPeriodicEvent(TimeSpan timePeriod, Action<GameManager> action)
    {
        Events.Add(Event.CreatePeriodicTimeEvent(timePeriod, action));
    }

    public void AddOnceTimeEvent(TimeSpan timePeriod, Action<GameManager> action)
    {
        Events.Add(Event.CreateOnceTimeEvent(timePeriod, action));
    }

    public void HandleEvents()
    {
        foreach (var @event  in Events)
        {
            if (@event.IsActive && @event.Ticks < DateTime.Now.Ticks)
                @event.DoEvent();
        }
    }
}

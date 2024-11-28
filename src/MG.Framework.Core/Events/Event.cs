using MG.Framework.Core.Events.Enums;
using MG.Framework.Core.Game;

namespace MG.Framework.Core.Events;

public class Event
{
    public long Ticks { get; private set; }
    public Action<GameManager> EventAction { get; init; }
    public EventTimeType EventTimeType { get; init; }
    public bool IsActive { get; private set; }  = true;
    public TimeSpan TimePeriod { get; private set; }

    private Event(TimeSpan timePeriod, Action<GameManager> eventAction, EventTimeType eventTimeType)
    {
        Ticks = DateTime.Now.Ticks + timePeriod.Ticks;
        EventAction = eventAction;
        EventTimeType = eventTimeType;
        TimePeriod = timePeriod;
    }

    public static Event CreateOnceTimeEvent(TimeSpan timePeriod, Action<GameManager> eventAction)
    {
        return new(timePeriod, eventAction, EventTimeType.Once);
    }

    public static Event CreatePeriodicTimeEvent(TimeSpan timePeriod, Action<GameManager> eventAction)
    {
        return new(timePeriod, eventAction, EventTimeType.Periodic);
    }

    public void DoEvent()
    {
        EventAction(GameManager.GetInstance());
        if (EventTimeType == EventTimeType.Periodic)
        {
            Ticks = DateTime.Now.Ticks + TimePeriod.Ticks;
            return;
        }

        IsActive = false;
    }

    public void TurnOff()
        => IsActive = false;

    public void TurnOn()
    {
        Ticks = DateTime.Now.Ticks + TimePeriod.Ticks;

        IsActive = true;
    }
}


using System;
namespace Done
{
    public class EventInfo<T> : IEventInfo
    {
        public Action<T> actions;
        public EventInfo(Action<T> action)
        {
            actions += action;
        }
    }

    public class EventInfo : IEventInfo
    {
        public Action actions;
        public EventInfo(Action action)
        {
            actions += action;
        }
    }
}


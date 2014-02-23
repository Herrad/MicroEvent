using System;

namespace MicroEvent
{
    public abstract class Subscription
    {
        protected Subscription(Type eventType)
        {
            EventType = eventType;
        }

        public Type EventType { get; protected set; }
        public abstract void Notify(AnEvent anEvent);
    }
}
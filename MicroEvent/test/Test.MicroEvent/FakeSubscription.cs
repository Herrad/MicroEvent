using System;
using MicroEvent;

namespace Test.MicroEvent
{
    public class FakeSubscription : Subscription
    {
        public FakeSubscription(Type eventType) : base(eventType)
        {
        }

        public AnEvent LastEvent { get; private set; }
        public override void Notify(AnEvent anEvent)
        {
            LastEvent = anEvent;
        }
    }
}
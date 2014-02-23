using MicroEvent;

namespace Test.MicroEvent
{
    public class FakeSubscriber : Subscriber
    {
        public AnEvent LastEvent { get; private set; }
        public override void Notify(AnEvent anEvent)
        {
            LastEvent = anEvent;
        }
    }
}
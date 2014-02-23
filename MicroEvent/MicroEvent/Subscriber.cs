namespace MicroEvent
{
    public abstract class Subscriber
    {
        public abstract void Notify(AnEvent anEvent);
    }
}
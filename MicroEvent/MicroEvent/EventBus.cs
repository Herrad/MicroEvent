using System;
using System.Collections.Generic;

namespace MicroEvent
{
    public class EventBus
    {
        private readonly IList<Subscriber> _subscriptionList;
        private readonly IList<AnEvent> _eventStore;

        public EventBus(IList<Subscriber> subscriptionList, IList<AnEvent> eventStore)
        {
            _subscriptionList = subscriptionList;
            _eventStore = eventStore;
        }

        public void Subscribe(Subscriber subscriber)
        {
            _subscriptionList.Add(subscriber);
        }

        public void Publish(AnEvent anEvent)
        {
            _eventStore.Add(anEvent);
            foreach (var subscriber in _subscriptionList)
            {
                subscriber.Notify(anEvent);
            }
        }
    }
}
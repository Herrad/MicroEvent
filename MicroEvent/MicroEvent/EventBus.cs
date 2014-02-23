using System;
using System.Collections.Generic;

namespace MicroEvent
{
    public class EventBus
    {
        private readonly IList<Subscriber> _subscriptionList;

        public EventBus(IList<Subscriber> subscriptionList, List<AnEvent> eventStore)
        {
            _subscriptionList = subscriptionList;
        }

        public void Subscribe(Subscriber subscriber)
        {
            _subscriptionList.Add(subscriber);
        }

        public void Publish(AnEvent anEvent)
        {
            throw new NotImplementedException();
        }
    }
}
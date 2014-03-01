using System;
using System.Collections.Generic;
using System.Linq;

namespace MicroEvent
{
    public class EventBus
    {
        private readonly IList<Subscription> _subscriptionList;
        private readonly IList<AnEvent> _eventStore;

        public EventBus(IList<Subscription> subscriptionList, IList<AnEvent> eventStore)
        {
            _subscriptionList = subscriptionList;
            _eventStore = eventStore;
        }

        public void Subscribe(Subscription subscription)
        {
            _subscriptionList.Add(subscription);
        }

        public void Publish(AnEvent anEvent)
        {
            _eventStore.Add(anEvent);

            foreach (var subscription in GetSubscriptionsToPublishedEvent(anEvent))
            {
                subscription.Notify(anEvent);
            }
        }

        private IEnumerable<Subscription> GetSubscriptionsToPublishedEvent(AnEvent anEvent)
        {
            Console.WriteLine("selected event: " + anEvent.GetType());
            foreach (var subscription in _subscriptionList)
            {
                Console.WriteLine(subscription.EventType);
            }
            return _subscriptionList.Where(subscription => subscription.EventType == anEvent.GetType());
        }
    }
}
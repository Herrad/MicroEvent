using System;
using System.Collections.Generic;

namespace MicroEvent
{
    public class EventBus
    {
        public EventBus(IEnumerable<Subscriber> subscriptionList)
        {
            
        }

        public void Subscribe(Subscriber publishingAnEventSteps)
        {
            throw new NotImplementedException();
        }

        public void Publish(AnEvent anEvent)
        {
            throw new NotImplementedException();
        }
    }
}
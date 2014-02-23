using System.Collections.Generic;
using MicroEvent;
using NUnit.Framework;

namespace Test.MicroEvent
{

    [TestFixture]
    public class TestEventBus
    {
        [Test]
        public void Subscribing_to_an_event_adds_the_subscriber_to_the_subscription_list()
        {
            var subscriptionList = new List<Subscriber>();

            var eventBus = new EventBus(subscriptionList, null);

            var subscriber = new FakeSubscriber();

            eventBus.Subscribe(subscriber);

            Assert.That(subscriptionList.Contains(subscriber));
        }

        [Test]
        public void Published_event_is_added_to_event_store()
        {
            var eventStore = new List<AnEvent>();

            var eventBus = new EventBus(null, eventStore);

            var fakeEvent = new FakeEvent();

            eventBus.Publish(fakeEvent);

            Assert.That(eventStore.Contains(fakeEvent));
        }
    }
}

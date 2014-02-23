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

            var eventBus = new EventBus(subscriptionList);

            var subscriber = new FakeSubscriber();

            eventBus.Subscribe(subscriber);

            Assert.That(subscriptionList.Contains(subscriber));
        }
    }
}

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
            var subscriptionList = new List<Subscription>();

            var eventBus = new EventBus(subscriptionList, null);

            var subscriber = new FakeSubscription(typeof(AnEvent));

            eventBus.Subscribe(subscriber);

            Assert.That(subscriptionList.Contains(subscriber));
        }

        [Test]
        public void Published_event_is_added_to_event_store()
        {
            var eventStore = new List<AnEvent>();

            var eventBus = new EventBus(new List<Subscription>(), eventStore);

            var fakeEvent = new FakeEvent();

            eventBus.Publish(fakeEvent);

            Assert.That(eventStore.Contains(fakeEvent));
        }

        [Test]
        public void Subscribers_are_notified_when_their_event_occurs()
        {
            var subscriptionList = new List<Subscription>
            {
                new FakeSubscription(typeof(FakeEvent)),
                new FakeSubscription(typeof(FakeEvent)),
                new FakeSubscription(typeof(FakeEvent))
            };

            var eventBus = new EventBus(subscriptionList, new List<AnEvent>());

            var fakeEvent = new FakeEvent();

            eventBus.Publish(fakeEvent);

            Assert.That(((FakeSubscription)subscriptionList[0]).LastEvent, Is.EqualTo(fakeEvent));
            Assert.That(((FakeSubscription)subscriptionList[1]).LastEvent, Is.EqualTo(fakeEvent));
            Assert.That(((FakeSubscription)subscriptionList[2]).LastEvent, Is.EqualTo(fakeEvent));
        }

        [Test]
        public void Subscriptions_to_events_are_not_notified_when_different_event_types_are_published()
        {
            var subscriptionList = new List<Subscription>
            {
                new FakeSubscription(typeof(FakeEvent)),
                new FakeSubscription(typeof(AnotherEvent)),
                new FakeSubscription(typeof(FakeEvent))
            };

            var eventBus = new EventBus(subscriptionList, new List<AnEvent>());

            var fakeEvent = new FakeEvent();

            eventBus.Publish(fakeEvent);

            Assert.That(((FakeSubscription)subscriptionList[0]).LastEvent, Is.EqualTo(fakeEvent));
            Assert.That(((FakeSubscription)subscriptionList[1]).LastEvent, Is.Null);
            Assert.That(((FakeSubscription)subscriptionList[2]).LastEvent, Is.EqualTo(fakeEvent));
        }
    }
}

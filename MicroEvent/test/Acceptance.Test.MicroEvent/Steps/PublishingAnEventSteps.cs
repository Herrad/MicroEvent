using System;
using System.Collections.Generic;
using MicroEvent;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Acceptance.Test.MicroEvent.Steps
{
    [Binding]
    public class PublishingAnEventSteps 
    {
        private class NotifyingExposureSubscription : Subscription
        {
            public NotifyingExposureSubscription(Type eventType) : base(eventType)
            {
                WasNotified = false;
            }

            public override void Notify(AnEvent anEvent)
            {
                WasNotified = true;
            }

            public bool WasNotified { get; set; }
        }


        private static void CreateEventBusSubscribedToEventsOfType(Type eventType)
        {
            var subscription = new NotifyingExposureSubscription(eventType);
            ScenarioContext.Current["subscription"] = subscription;

            var subscriptionList = new List<Subscription>();
            var eventBus = new EventBus(subscriptionList, new List<AnEvent>());
            eventBus.Subscribe(subscription);

            ScenarioContext.Current["bus"] = eventBus;
        }

        [Given(@"I am subscribed to TestEvents")]
        public void GivenIAmSubscribedToTestEvents()
        {
            CreateEventBusSubscribedToEventsOfType(typeof (TestEvent));
        }

        [Given(@"I am subscribed to OtherEvents")]
        public void GivenIAmSubscribedToOtherEvents()
        {
            CreateEventBusSubscribedToEventsOfType(typeof(OtherEvent));
        }


        [When(@"a TestEvent is published")]
        public void WhenATestEventIsPublished()
        {
            var bus = (EventBus) ScenarioContext.Current["bus"];

            bus.Publish(new TestEvent());
        }

        [Then(@"I am notified")]
        public void ThenIAmNotified()
        {
            var subscription = (NotifyingExposureSubscription) ScenarioContext.Current["subscription"];
            Assert.That(subscription.WasNotified);
        }

        [Then(@"I am not notified")]
        public void ThenIAmNotNotified()
        {
            var subscription = (NotifyingExposureSubscription)ScenarioContext.Current["subscription"];
            Assert.That(subscription.WasNotified, Is.False);
        }
    }
}

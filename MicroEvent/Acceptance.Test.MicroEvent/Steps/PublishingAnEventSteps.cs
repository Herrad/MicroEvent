using System.Collections.Generic;
using MicroEvent;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Acceptance.Test.MicroEvent.Steps
{
    [Binding]
    public class PublishingAnEventSteps : Subscriber
    {
        private bool _iWasNotified;

        [BeforeScenario]
        public void SetUp()
        {
            _iWasNotified = false;
        }

        [Given(@"I am subscribed to TestEvents")]
        public void GivenIAmSubscribedToTestEvents()
        {
            Subscriber subscriber = this;
            var subscriptionList = new List<Subscriber>();
            var eventBus = new EventBus(subscriptionList, new List<AnEvent>());
            eventBus.Subscribe(subscriber);

            ScenarioContext.Current["bus"] = eventBus;
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
            Assert.That(_iWasNotified);
        }

        public override void Notify(AnEvent anEvent)
        {
            _iWasNotified = true;
        }
    }

    public class TestEvent : AnEvent
    {
    }
}

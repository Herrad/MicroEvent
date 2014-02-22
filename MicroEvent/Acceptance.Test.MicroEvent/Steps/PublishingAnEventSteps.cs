using System;
using TechTalk.SpecFlow;

namespace Acceptance.Test.MicroEvent.Steps
{
    [Binding]
    public class PublishingAnEventSteps
    {
        [Given(@"I have a data store")]
        public void GivenIHaveADataStore()
        {
            
        }

        [Given(@"a service front end")]
        public void GivenAServiceFrontEnd()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I publish an event via the service")]
        public void WhenIPublishAnEventViaTheService()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a write event is triggered")]
        public void ThenAWriteEventIsTriggered()
        {
            ScenarioContext.Current.Pending();
        }
    }
}

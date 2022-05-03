using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class E_CommerceAPITestsStepDefinitions
    {
        [Given(@"that the endpoint url is '([^']*)'")]
        public void GivenThatTheEndpointUrlIs(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the API is requested")]
        public void WhenTheAPIIsRequested()
        {
            throw new PendingStepException();
        }

        [Then(@"the status code should be '([^']*)'")]
        public void ThenTheStatusCodeShouldBe(string oK)
        {
            throw new PendingStepException();
        }

        [Then(@"a response list typed '([^']*)' must be received with the following datatypes")]
        public void ThenAResponseListTypedMustBeReceivedWithTheFollowingDatatypes(string p0, Table table)
        {
            throw new PendingStepException();
        }
    }
}

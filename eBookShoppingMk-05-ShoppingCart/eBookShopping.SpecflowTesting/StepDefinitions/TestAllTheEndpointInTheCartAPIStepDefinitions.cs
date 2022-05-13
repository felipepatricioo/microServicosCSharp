using System;
using System.Collections;
using TechTalk.SpecFlow;

namespace eBookShopping.SpecflowTesting.StepDefinitions
{
    [Binding]
    public class TestAllTheEndpointInTheCartAPIStepDefinitions
    {

        private HttpClient _httpClient;
        private HttpResponseMessage _httpResponseMessage;
        private const string BASE_URL = "https://localhost:44565";


        [Given(@"The user id is '([^']*)'")]
        public void GivenTheUserIdIs(string userId)
        {

            _httpClient = new HttpClient();

            Task<IEnumerable<Cart>> teste = _httpClient.GetAsync(BASE_URL + $"/find-cart/{userId}");

            

            _httpResponseMessage = teste;




        }

        [When(@"I call the cart API")]
        public void WhenICallTheCartAPI()
        {
            throw new PendingStepException();
        }

        [Then(@"the status code should be '([^']*)'")]
        public void ThenTheStatusCodeShouldBe(string p0)
        {
            throw new PendingStepException();
        }
    }
}

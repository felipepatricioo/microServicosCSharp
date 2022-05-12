using Newtonsoft.Json;
using System;
using System.Text;
using TechTalk.SpecFlow;

namespace eBookShopping.SpecflowTesting.StepDefinitions
{
    [Binding]
    public class CartRequestsStepDefinitions
    {

        private HttpClient _httpClient;
        private HttpResponseMessage _httpResponseMessage;
        private string BASE_URL = "https://localhost:44565/api/v1/Cart";
        private readonly ScenarioContext _scenarioContext;

        [Given(@"that the cart's user id is ""([^""]*)""")]
        public void GivenThatTheCartsUserIdIs(string userId)
        {
            _scenarioContext["UserId"] = userId;
        }

        [When(@"the api is called")]
        public async Task WhenTheApiIsCalled()
        {
            _httpClient = new HttpClient();

            var transactionData = product.CreateInstance<Product>();
            var productJson = JsonConvert.SerializeObject(transactionData);
            _httpResponseMessage = await _httpClient.PostAsync(BASE_URL,
                new StringContent(
                    productJson,
                    Encoding.UTF8,
                    "application/json")
                );
        }

        [Then(@"the status cod hould be '([^']*)'")]
        public void ThenTheStatusCodHouldBe(string oK)
        {
            throw new PendingStepException();
        }
    }
}

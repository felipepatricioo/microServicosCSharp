using eBookShopping.SpecflowTesting.Models;
using System;
using TechTalk.SpecFlow;

namespace eBookShopping.SpecflowTesting.StepDefinitions
{
    [Binding]
    public class GetAllProductsStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly HttpClient _httpClient;
        private const string BASE_URL = "https://localhost:4440/api/v1/Product";

        [When(@"The API is called")]
        public async Task WhenTheAPIIsCalled()
        {

            var client = new HttpClient();
           



   



        }

        [Then(@"Return all the products in the database successfully")]
        public void ThenReturnAllTheProductsInTheDatabaseSuccessfully()
        {
            throw new PendingStepException();
        }
    }
}

using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Net.Http.Json;
using System.Net;
using eBookShopping.SpecflowTesting.Models;
using System.Text.Json;

namespace eBookShopping.SpecflowTesting.StepDefinitions
{
    [Binding]
    public class ProductTestingStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly HttpClient _httpClient;    
        private const string BASE_URL = "https://localhost:4440/api/v1/Product";

        ProductTestingStepDefinitions(ScenarioContext scenarioContext, HttpClient httpClient)
        {
            _scenarioContext = scenarioContext;
            _httpClient = httpClient;
        }


        [When(@"I create a product with the following details")]
        public void WhenICreateAProductWithTheFollowingDetails(Table product)
        {
            _scenarioContext["Product"] = product;
        }

        [Then(@"The product is created successfully")]
        public async Task ThenTheProductIsCreatedSuccessfully()
        {
            var product = _scenarioContext.Get<Product>("Product");
            var response = await _httpClient.PostAsJsonAsync(BASE_URL, product);
            response.StatusCode.Should().Be(HttpStatusCode.Created);

        }

        [When(@"the API is called")]
        public async Task WhenTheAPIIsCalled()
        {
            var response = await _httpClient.GetAsync(BASE_URL);
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            _scenarioContext["Products"] = JsonSerializer.Deserialize<Product>(dataAsString,
                new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true });
        }

        [Then(@"the response should be all the products in the database")]
        public void ThenTheResponseShouldBeAllTheProductsInTheDatabase()
        {
            var teste = _scenarioContext["Products"];
            Console.WriteLine(teste);
        }


    }
}

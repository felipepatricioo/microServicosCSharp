using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Net.Http.Json;
using System.Net;
using eBookShopping.SpecflowTesting.Models;

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
            JsonContent content = JsonContent.Create(product);
            var response = await _httpClient.PostAsync(BASE_URL, content);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

        }
    }
}

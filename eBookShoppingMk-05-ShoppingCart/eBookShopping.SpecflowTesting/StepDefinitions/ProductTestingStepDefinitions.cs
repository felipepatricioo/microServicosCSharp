using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Net;
using eBookShopping.SpecflowTesting.Models;

namespace eBookShopping.SpecflowTesting.StepDefinitions
{
    [Binding]
    public class ProductTestingStepDefinitions
    {
        private HttpClient _httpClient;
        private HttpResponseMessage _httpResponseMessage;
        private const string BASE_URL = "https://localhost:44395/api/v1/Product";


        [Given(@"I have a web client")]
        public void GivenIHaveAWebClient()
        {
            _httpClient = new HttpClient();
        }

        [When(@"I want to get the web page '(.*)'")]
        public async Task WhenIWantToGetTheWebPage(string url)
        {
            _httpResponseMessage = await _httpClient.GetAsync(url);
            Console.WriteLine(_httpResponseMessage);
        }

        [Then(@"the result should have status code '(.*)'")]
        public void ThenTheResultShouldHaveStatusCode(int expectedStatusCode)
        {
            _httpResponseMessage.StatusCode.Should().Be((HttpStatusCode)expectedStatusCode);
        }



        [When(@"I create a product with the following details")]
        public async Task WhenICreateAProductWithTheFollowingDetails(Table product)
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

                    //The HttpClient type is a newer implementation than the WebClient and HttpWebRequest. Both the WebClient and WebRequest have been marked as obsolete. [1]

                    //You can simply use the following lines.

                    //string myJson = "{'Username': 'myusername','Password':'pass'}";
                    //            using (var client = new HttpClient())
                    //            {
                    //                var response = await client.PostAsync(
                    //                    "http://yourUrl",
                    //                     new StringContent(myJson, Encoding.UTF8, "application/json"));
                    //            }
                    //            When you need your HttpClient more than once it's recommended to only create one instance and reuse it or use the new HttpClientFactory. [2]

                    //For FTP, since HttpClient doesn't support it, we recommend using a third-party library.

                    //@docs.microsoft.com[3]

                    //Since dotnet core 3.1 you can use the JsonSerializer from System.Text.Json to create your json string.

                    //string myJson = JsonSerializer.Serialize(credentialsObj);

        }


        [Then(@"The product is created successfully")]
        public void ThenTheProductIsCreatedSuccessfully(int expectedStatusCode)
        {
            var product = _scenarioContext.Get<Product>("Product");
            JsonContent content = JsonContent.Create(product);
            var response = await _httpClient.PostAsync(BASE_URL, content);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

        }
    }
}

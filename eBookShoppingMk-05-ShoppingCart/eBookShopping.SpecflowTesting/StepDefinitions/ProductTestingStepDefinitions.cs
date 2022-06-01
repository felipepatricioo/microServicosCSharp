using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Net;
using eBookShopping.SpecflowTesting.Models;
using Newtonsoft.Json;
using System.Text;
using eBookShopping.ProductAPI.Models;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace eBookShopping.SpecflowTesting.StepDefinitions
{
    [Binding]
    public class ProductTestingStepDefinitions
    {
        private HttpClient _httpClient;
        private HttpResponseMessage _httpResponseMessage;
        private const string BASE_URL = "https://localhost:44395/api/v1/Product";
        private string IDSERVER_URL = "https://localhost:4435";
        private readonly ScenarioContext _scenarioContext;

        internal async Task<ResponseModel> GetToken()
        {
            _httpClient = new HttpClient();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", "client"),
                new KeyValuePair<string, string>("client_secret", "my_super_secret"),
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

            var request = await _httpClient.PostAsync(IDSERVER_URL + "/connect/token", content);
            var requestContent = await request.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ResponseModel>(requestContent);

            return result;
        }

        public ProductTestingStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

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

        [Given(@"The user is authenticated")]
        public async Task GivenTheUserIsAuthenticated()
        {
            ResponseModel response = await GetToken();
            _scenarioContext["token"] = response.access_token;

        }

        [When(@"I create a product with the following details")]
        public async Task WhenICreateAProductWithTheFollowingDetails(Table product)
        {
            _httpClient = new HttpClient();

            var token = (string)_scenarioContext["token"];

            Console.WriteLine(token);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var transactionData = product.CreateInstance<ProductModel>();
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
        public async Task ThenTheProductIsCreatedSuccessfullyAsync(int expectedStatusCode)
        {
            _httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.Created);
        }


        [When(@"i update a product with the following details")]
        public async Task WhenIUpdateAProductWithTheFollowingDetails(Table product)
        {
            _httpClient = new HttpClient();

            ResponseModel response = await GetToken();
            _scenarioContext["token"] = response.access_token;
            var token = (string)_scenarioContext["token"];

            Console.WriteLine(token);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var transactionData = product.CreateInstance<ProductModel>();
            var productJson = JsonConvert.SerializeObject(transactionData);
            _httpResponseMessage = await _httpClient.PutAsync(BASE_URL,
                new StringContent(
                    productJson,
                    Encoding.UTF8,
                    "application/json")
                );
        }


        [Given(@"That the user is authenticated")]
        public async Task GivenThatTheUserIsAuthenticated()
        {
            ResponseModel response = await GetToken();
            _scenarioContext["token"] = response.access_token;
        }

        [When(@"id delete the product with the id '([^']*)'")]
        public async Task WhenIdDeleteTheProductWithTheId(string productId)
        {
            _httpClient = new HttpClient();
            var token = (string)_scenarioContext["token"];

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            _httpResponseMessage = await _httpClient.DeleteAsync(BASE_URL + $"/{productId}");
        }

        [Then(@"the result should have status '([^']*)'")]
        public void ThenTheResultShouldHaveStatus(int expectedStatus)
        {
            _httpResponseMessage.StatusCode.Should().Be((HttpStatusCode)expectedStatus);
        }

    }
}

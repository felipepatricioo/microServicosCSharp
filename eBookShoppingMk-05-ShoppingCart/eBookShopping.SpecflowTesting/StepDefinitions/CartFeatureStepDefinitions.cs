using eBookShopping.SpecflowTesting.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;

namespace eBookShopping.SpecflowTesting.StepDefinitions
{
    [Binding]
    public class CartFeatureStepDefinitions
    {
        private HttpClient _httpClient;
        private HttpResponseMessage _httpResponseMessage;
        private string BASE_URL = "https://localhost:44565/api/v1/Cart";
        private string IDSERVER_URL = "https://localhost:4435";
        private readonly ScenarioContext _scenarioContext;

        public CartFeatureStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }



        [Given(@"That the user is authenticated")]
        public async Task GivenThatTheUserIsAuthenticated()
        {
            _httpClient = new HttpClient();

            var requestContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", "client"),
                new KeyValuePair<string, string>("client_secret", "my_super_secret"),
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

            var response = await _httpClient.PostAsync(IDSERVER_URL + "/connect/token", requestContent);

            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(response);
            Console.WriteLine(responseContent);
        }

        [When(@"the api is requested")]
        public async Task WhenTheApiIsRequested()
        {
            var userId = "75cc6626-dc69-4e81-95e4-9b0c0817160a";
            _httpClient = new HttpClient();

            var cartDetail = new List<CartDetailModel>();
            cartDetail.Add(new CartDetailModel
            {
                Id = 0,
                CartHeaderId = 0,
                CartHeader = new CartHeaderModel()
                {
                    Id = 0,
                    UserId = (string)userId,
                    CouponCode = ""
                },
                ProductId = 11,
                Product = new ProductModel()
                {
                    id = 11,
                    name = "Posthumous Memoirs of Brás Cubas",
                    price = new decimal(9.90),
                    description = "A novel by Machado de Assis",
                    categoryName = "Novel",
                    imageUrl = "https://images-na.ssl-images-amazon.com/images/I/71pZaZtyN2L.jpg"
                },
                Count = 69
            });

            var cart = new CartModel()
            {
                CartHeader = new CartHeaderModel()
                {
                    Id = 0,
                    UserId = (string)userId,
                    CouponCode = ""
                },
                CartDetails = cartDetail,
            };

            var cartJson = JsonConvert.SerializeObject(cart);
            _httpResponseMessage = await _httpClient.PostAsync(BASE_URL + "/add-cart",
                new StringContent(
                    cartJson,
                    Encoding.UTF8,
                    "application/json")
                );
        }

        [Then(@"the status code should be '([^']*)'")]
        public void ThenTheStatusCodeShouldBe(int expectedStatusCode)
        {
            _httpResponseMessage.StatusCode.Should().Be((HttpStatusCode)expectedStatusCode);
        }

    }
}

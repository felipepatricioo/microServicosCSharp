using eBookShopping.SpecflowTesting.Models;
using Newtonsoft.Json;
using System;
using System.Net;
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
        private string IDSERVER_URL = "https://localhost:4435";
        private readonly ScenarioContext _scenarioContext;

        [Given(@"That the user is authenticated")]
        public async Task GivenThatTheUserIsAuthenticated()
        {
            _httpClient = new HttpClient();
            
            LoginModel login = new LoginModel()
            {
                Username = "felipe-admin",
                Password = "Felipe123$"
            };

            var loginJson = JsonConvert.SerializeObject(login);
            _scenarioContext["token"] =  await _httpClient.PostAsync(IDSERVER_URL + "/add-cart",
                new StringContent(
                    loginJson,
                    Encoding.UTF8,
                    "application/json")
                );
            Console.WriteLine(loginJson);
        }


        [When(@"the api is called")]
        public async Task WhenTheApiIsCalled()
        {
            _httpClient = new HttpClient();

            var userId = _scenarioContext["UserId"];

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
                ProductId = 2,
                Product = new ProductModel()
                {
                    id = 11,
                    name = "Posthumous Memoirs of Brás Cubas",
                    price = new decimal(9.90),
                    description = "A novel by Machado de Assis",
                    categoryName = "Novel",
                    imageUrl = "https://images-na.ssl-images-amazon.com/images/I/71pZaZtyN2L.jpg"
                },
                Count = 16
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

        [Then(@"the status cod hould be '([^']*)'")]
        public void ThenTheStatusCodHouldBe(string oK)
        {
            _httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}

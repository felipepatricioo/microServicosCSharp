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

<<<<<<< HEAD
        [Given(@"that the cart s user id is '([^']*)'")]
        public void GivenThatTheCartSUserIdIs(string userId)
        {
            _scenarioContext["userId"] = userId;
=======
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
>>>>>>> f29831dd0e534753193b1f45b95d111f8f6691c0
        }


        [When(@"the api is called")]
        public async Task WhenTheApiIsCalled()
        {
            var userId = _scenarioContext["userId"];
            _httpClient = new HttpClient();

<<<<<<< HEAD
=======
            var userId = _scenarioContext["UserId"];

>>>>>>> f29831dd0e534753193b1f45b95d111f8f6691c0
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
<<<<<<< HEAD
                    name = "Posthumous Memoirs of Brás Cubas",
                    price = new decimal(9.900000000000000000000000000000),
=======
                    name = "Posthumous Memoirs of Br�s Cubas",
                    price = new decimal(9.90),
>>>>>>> f29831dd0e534753193b1f45b95d111f8f6691c0
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
<<<<<<< HEAD
            _httpResponseMessage = await _httpClient.PostAsync(BASE_URL + $"find-cart/{userId}",
=======
            _httpResponseMessage = await _httpClient.PostAsync(BASE_URL + "/add-cart",
>>>>>>> f29831dd0e534753193b1f45b95d111f8f6691c0
                new StringContent(
                    cartJson,
                    Encoding.UTF8,
                    "application/json")
                );
        }

        [Then(@"the status cod hould be '([^']*)'")]
        public void ThenTheStatusCodHouldBe(int expectedStatusCode)
        {
<<<<<<< HEAD
            _httpResponseMessage.StatusCode.Should().Be((HttpStatusCode)expectedStatusCode);
=======
            _httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.Created);
>>>>>>> f29831dd0e534753193b1f45b95d111f8f6691c0
        }
    }
}

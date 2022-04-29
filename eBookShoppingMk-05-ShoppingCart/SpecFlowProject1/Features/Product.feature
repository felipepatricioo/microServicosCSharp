Feature: E-Commerce API tests


Scenario: Get all the already registered products in the database
Given that the endpoint url is 'https://localhost:4440/api/v1/Product'
And the HTTP method is 'GET'
When the API is requested
Then the status code should be 'OK'
#And a response list typed 'eBookShopping.ProductAPI.Models.Product' must be received with the following datatypes
#| Name | Price | Description | CategoryName | ImageUrl |

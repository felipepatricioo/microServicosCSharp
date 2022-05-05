Feature: Product testing

Scenario: Create a product successfully 
When I create a product with the following details 
| Name          | Price | Description               | CategoryName | ImageUrl                                                         |
| Sun and Steel | 59.90 | An Essay By Yukio Mishima | Essay        | https://images-na.ssl-images-amazon.com/images/I/61yPkAMrCDL.jpg |
Then The product is created successfully


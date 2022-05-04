Feature: Manage Products in the system

Scenario: Product get created sucessfully
When I create a product with the following details 
| Name          | Price | Decription                | CategoryName | ImageUrl                                                         |
| Sun and Steel | 59.90 | An Essay by Yukio Mishima | Essay        | https://images-na.ssl-images-amazon.com/images/I/61yPkAMrCDL.jpg |
Then the product is created sucessfully
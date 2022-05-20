Feature: Product testing


Scenario: Get all the products in the database successfully
	Given I have a web client
	When I want to get the web page 'https://localhost:44395/api/v1/Product'
	Then the result should have status code '200'

Scenario: Create a product successfully
	When I create a product with the following details
		| id | name                                        | price | description               | categoryName | imageUrl                                                         |
		| 10 | The Sailor who fell from grace with the sea | 59.90 | An Novel By Yukio Mishima | Novel        | https://images-na.ssl-images-amazon.com/images/I/91VHGE-qsxL.jpg |
	Then the result should have status code '200'

Scenario: Update a product sucessfully
	When i update a product with the following details
	| id | name               | price     |
	| 56 | teste automatizado #3 | 100000.99 |
	Then the product is updated successfully

Scenario: Delete a product sucessfully
	When id delete the product with the id '100'
	Then the product is deleted successfully
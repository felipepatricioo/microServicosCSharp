Feature: Test all the endpoint in the cart API


Scenario: Get the shopping cart of an specific user
	Given That the user is authenticated 
	When I call the cart API 
	Then the status code should be '200'

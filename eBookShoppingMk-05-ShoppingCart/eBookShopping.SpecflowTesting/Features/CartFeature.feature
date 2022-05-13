Feature: Test all the endpoint in the cart API


Scenario: Get the shopping cart of an specific user
	Given The user id is '75cc6626-dc69-4e81-95e4-9b0c0817160a'
	When I call the cart API 
	Then the status code should be '200'

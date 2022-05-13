Feature: Cart Requests

A short summary of the feature

@tag1
Scenario: Add a product to the shopping cart
	Given that the cart's user id is "367fc356-cb4a-48bb-8295-9fd902729afa"
	When the api is called
	Then the status cod hould be 'OK'

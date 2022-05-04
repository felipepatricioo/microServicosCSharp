Feature: Product API -> Test all the product API features

Scenario: Get al the products registered in the database
	Given the API url is 'https://localhost:4440'
	And the HTTP Method is 'GET'
	When the request is made
	Then HTTP response should be 'OK'
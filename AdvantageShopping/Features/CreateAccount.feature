Feature: Create Account

Background: 
    Given I navigate to Advantage Online Shopping
	When I click on user icon to create new account
	Then I should see create new account page displayed

@createaccount
Scenario: Mandatory field error messages display & clear
    When I click on username field
	And I click on email field
	And I click on password field
	And I click on confirm password field
	And I click on First Name field
	Then I should see validation message errors on the Account Details fields

	When I enter '<Username>', '<Email>', '<Password>' and '<Confirm Password>'
	Then I should not see any validation messages on the fields

	Examples: 
	| Username    | Email                | Password   | Confirm Password |
	| TestAccount | TestAccount@test.com | Password1! | Password1!       |
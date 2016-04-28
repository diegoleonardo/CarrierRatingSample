Feature: Add User
	In order to use and rate a carrier in "Carrier Rating System"
	As a person
	I want to be able to create a account in system

@mytag
Scenario: Create User
	Given I have entered 'Diego' into the text field firstname
	And I have entered 'Leonardo' into the text field lastname
	And I have entered 'diegoleonardo@teste.com.br' into the text field email
	And I have entered '123456' into the text field password
	When I press create
	Then a message with 'success' should be displayed on the screen

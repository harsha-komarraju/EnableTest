Feature: Saucelab Website launch and login


Background: 
	Given open the Saucedemo website
	When login with username and password
	Then home screen is displayed

@regression
Scenario: Adding item to basket and make a payment
	Given home page is displayed
	And sort the list low to high
	When first item added to basket
	And open basket and finish payment
	Then order complete is seen 

Scenario: To check error message in your information screen
	Given home page is displayed
	When first item added to basket
	And open basket and leave personal information screen blank
	Then enter first name error screen is seen  
	And enter last name error screen is seen 
	And enter postal code error screen is seen

Feature: Validating search results
	Search with a keyword and validate if that appeard in the results 

	Background: 
	Given enable website is launched

@regression
Scenario: open search and search wickes
	Given search is selected
	When wickes keyword entered
	Then search word is displayed in results 

Scenario: open search and search enable
	Given search is selected
	When enable word is entered
	Then check if test fails when checked with wrong text
Feature: Widgets

A short summary of the feature

@tag1
Scenario: Selecting the Options from first dropdown in the dropdown menu
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Widgets" 
	When We click on the element with the text "Select Menu"
	When We select the option "Group 1, option 1" from the first dropdown
	Then Verify if the option "Group 1, option 1" is selected in the first dropdown

Scenario: Selecting the Options from second dropdown in the dropdown menu
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Widgets" 
	When We click on the element with the text "Select Menu"
	When We select the option "Mr." from the second dropdown
	Then Verify if the option "Mr." is selected in the first dropdown

Scenario: Selecting the Options from standard dropdown in the dropdown menu
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Widgets" 
	When We click on the element with the text "Select Menu"
	Then We select "Yellow" from the standard dropdown
	And Verify if "Yellow" is selected in the standard dropdown

Scenario: Selecting the option from the third dropdown in the dropdown menu
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Widgets" 
	When We click on the element with the text "Select Menu"
	Then We select "Black" from the third dropdown
	Then Verify if the option "Black" is selected in the first dropdown
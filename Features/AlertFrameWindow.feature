Feature: AlertFrameWindow

A short summary of the feature


Scenario: Handling the New Tab in Browser Window
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Alert"
	When We click on the element with the text "Browser Windows"
	And We click on the  button with the text "New Tab"
	Then The title of the page should be "This is a sample page"

Scenario: Handling the New Window in Browser Window
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Alert"
	When We click on the element with the text "Browser Windows"
	And We click on the  button with the text "New Window"
	Then The title of the page should be "This is a sample page"



Scenario: Handling the Alert in Browser Window
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Alert"
	When We click on the element with the text "Alerts"
	When We click on the Click me button "1"
	#When We wait for "5" seconds
	Then The alert should be displayed with the text "You clicked a button"

Scenario: Handling the Second alert in Browser Window
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Alert"
	When We click on the element with the text "Alerts"
	And We click on the Click me button with the text "On button click, alert will appear after 5 seconds"
	When We wait for "5" seconds
	Then The alert should be displayed with the text "This alert appeared after 5 seconds"

Scenario: Handling the Confirm Alert in Browser Window
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Alert"
	When We click on the element with the text "Alerts"
	And We click on the Click me button with the text "On button click, confirm box will appear"
	Then The alert should be displayed with the text "Do you confirm action?"

Scenario: Handling the Prompt Alert in Browser Window
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Alert"
	When We click on the element with the text "Alerts"
	And We click on the Click me button with the text "On button click, prompt box will appear"
	Then The alert should be displayed with the text "Please enter your name"
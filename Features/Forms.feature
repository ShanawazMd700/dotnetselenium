﻿Feature: Forms

A short summary of the feature

@tag1
Scenario: Filling the practise form
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Forms"
	When We click on the element with the text "Practice Form"
	When We enter the user's "First Name" as "Will"
	When We enter the user's "Last Name" as "Smith"
	When we enter the user's email as "will.smith@mib.com"
	When We select gender as "Male"
	When We enter the users mobile number as "9948623909"
	When We select the subject as "English"
	When We select the radiobutton "Sports"
	When We upload a file with the path "resources\sampleFile.jpeg"
	When we select the state "NCR"
	When We select the city "Delhi"
	When We select the year "2029" and month "January" and the day "9"
	When We fill in the field with the label Current Address with the value "123 Main St,Standard Avenel,Middlesex County,07001."
	And We click on the  button with the text "Submit"
	Then We the text "Thanks for submitting the form" should be displayed
 

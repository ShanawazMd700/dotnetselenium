Feature: Interactions

A short summary of the feature

@tag1
Scenario: Performing a simple interaction of drag and drop
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Dragabble"
	When We drag the element with the text "Drag me" into the box
	Then Verify if the dragging is done for the element with the text "Drag me"

Scenario: Performing a simple drag and drop
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Droppable"
	When We drag the element with the text "Drag me" into the box with the text "Drop here"
	Then Verify if the dropping is done for the box with the text "Drop here"

Scenario: Performing the drag and drop of two elements into a box
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Droppable"
	When We select the side option as "Accept"
	When We drag the first box	
	Then verify the first drag

	
Scenario: Performing the drag and drop of second element into a box
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Droppable"
	When We select the side option as "Accept"
	When We drag second box
	Then verify the second drag

Scenario: Performing a drag in  Prevent Propogation outerbox
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Droppable"
	When We select the side option as "Prevent Propogation"
	When We drag the element with the text "Drag Me" into the outer box
	Then Verify if the dropping is done for the outer box and the text "Dropped!" is displayed

Scenario: Performing a drag in Prevent Propogation innerbox
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Droppable"
	When We select the side option as "Prevent Propogation"
	When We drag the element with the text "Drag Me" into the inner box
	Then Verify if the dropping is done for the inner box and the text "Dropped!" is displayed

Scenario: Performing a drag interaction into other box in Prevent Propogation 
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Droppable"
	When We select the side option as "Prevent Propogation"
	When We drag the element with the text "Drag Me" into other outer box
	Then Verify if the dropping is done for the other outer box and the text "Dropped!" is displayed

#Scenario: Performing a drag interaction into other inner box in Prevent Propogation 
#	Given We go to the page "https://demoqa.com/"
#	And We click on the element with the text "Interactions" 
#	When We click on the element with the text "Droppable"
#	When We select the side option as "Prevent Propogation"
#	When We drag the element with the text "Drag Me" into other inner box
#	Then Verify if the dropping is done for the other inner box and the text "Dropped!" is displayed

Scenario: Performing a drag interaction into the box in Revert Draggable
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Droppable"
	When We select the side option as "Revert Draggable"
	When We drag the element with text "Will Revert" into the box with the text Drop here
	Then Verify if the text "Dropped!" is displayed in the box
	When We wait for "5" seconds
	Then Verify if the element with the text Will Revert has reverted back to its original position

Scenario: Performing a drag interaction into the box in Revert Draggable for element that does not revert
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Droppable"
	When We select the side option as "Revert Draggable"
	When We drag the element with text "Not Revert" into the box with the text Drop here
	Then Verify if the text "Dropped!" is displayed in the box

Scenario: Performing a simple interaction of resizing
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Resizable"
	And We resize the box with x cordinates "300" and y coordinates "200"
	Then Verify if the resizing is done with x coordinates "300" and y coordinates "200"

Scenario: Performing a simple interaction of resizing without limitation
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Resizable"
	When We resize thee other box with the X coordinate "350" and Y coordinate "250"
	Then Verify if the resizing is done for the other box with x coordinates "350" and y coordinates "250"

Scenario: Performing a simple interaction of selecting items
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Selectable"
	When We select the item with the text "Cras justo odio" 
	Then Verify if the item with the text "Cras justo odio" is selected

Scenario: performing a simple Interaction of selecting items in other tab
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Selectable"
	When We opened the link containing "Grid"
	When We select the item with the text "One"
	Then Verify if the item with the text "One" is selected

Scenario:Performing a simple interaction of sorting items
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Sortable"
	When We sort the item with text "One" to the position of item "Four"
	#Then Verify if the item with text "Item 1" is in the position of item "Item 4"
Scenario: Performing a simple interaction of sorting items in other tab
	Given We go to the page "https://demoqa.com/"
	And We click on the element with the text "Interactions" 
	When We click on the element with the text "Sortable"
	When We opened the link containing "Grid"
	When We sort the item with text  "One" to the position of item "Four"
	#Then Verify if the item with text "One" is in the position of item "Four"
Feature: Bitmap Renderer


Scenario: Render 1 pixel bitmap to a single colour
	Given I have a bitmap of width 1 and height 1
	And a colour table of 2 steps
	And a start color of 0, 0, 0 and an end color of 255, 255, 255
	And a calculated grid of width 1 and height 1


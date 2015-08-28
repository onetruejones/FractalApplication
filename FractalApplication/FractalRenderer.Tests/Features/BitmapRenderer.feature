Feature: Bitmap Renderer


Scenario Outline: Render 1 pixel bitmap to a single colour
	Given I have a bitmap of width <Width> and height <Height>
	And a colour table of <Steps> steps
	And a start color of <StartR>, <StartG>, <StartB> and an end color of <EndR>, <EndG>, <EndB>
	And a calculated grid of width <Width> and height <Height>
	And the calculated grid has a value of <Value> in position <X>, <Y>
	When I render the bitmap from the grid data
	Then the bitmap pixel at <X>, <Y> has the colour at position <Value> in the colour table
Examples:
| Width | Height | Steps | X | Y | Value | StartR | StartG | StartB | EndR | EndG | EndB |
| 1     | 1      | 2     | 0 | 0 | 1     | 0      | 0      | 0      | 255  | 255  | 255  |
| 10    | 10     | 10    | 5 | 4 | 5     | 255    | 255    | 255    | 0    | 0    | 0    |
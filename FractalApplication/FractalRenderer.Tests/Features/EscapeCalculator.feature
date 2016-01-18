Feature: EscapeCalculator

Scenario: Calculate escape time for point outside circle of radius 2
	Given I have a maximum iteration value of 10
	And a start point of 10 by 10
	When I run the iteration algorithm
	Then the number of iterations returned should be 1

Scenario: Calculate escape time for the origin
	Given I have a maximum iteration value of 10
	And a start point of 0 by 0
	When I run the iteration algorithm
	Then the number of iterations returned should be 10

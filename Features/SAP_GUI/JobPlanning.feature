@Job_Planning
Feature: Job Planning 

Background: SAP is open and logged in
	Given SAP is open and logged in

Scenario: AG01 SOP and complete job planning, release and schedule work
	When The user set operation to SOP and completes planning using the test set "AG01SOPAndCompletePlanningOperation"
	And The user release the work
	Then The user validates that the work has been released
	When The user schedule the work
	Then The user validates that the work has been scheduled
	And The user logs out

Scenario: AG02 SOP and complete job planning, release and schedule work
	When The user set operation to SOP and completes planning using the test set "AG02SOPAndCompletePlanningOperation"
	And The user release the work
	Then The user validates that the work has been released
	When The user schedule the work
	Then The user validates that the work has been scheduled
	And The user logs out



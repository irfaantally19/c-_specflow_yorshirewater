@ScheduledMaintenancePlan
Feature: Scheduled Maintenance Plan 
Schedule a new maintenance plan

Background: SAP is open and logged in
	Given SAP is open and logged in


Scenario Outline: Scheduled single maintenance plan
	When The user creates a new <Plan Type> item maintenance plan using the test set "<Test Set>"
	Then The user validates the <Plan Type> item maintenance plan
	When The user Schedules a maintenance plan
	Then The user Releases the call
	Then The user Displays the call object and extracts the order number
	Then The user completed the call
	Then The user logs out


	Examples: 
	| Variable  | Plan Type | Test Set                                |
	| AG01      | single    | CreateAG01SingleItemMaintenancePlan     |
	| AG01/Mech | single    | CreateAG01SingleItemMaintenancePlanMECH |
	| AG02      | single    | CreateAG02SingleItemMaintenancePlan     |
	


	Scenario Outline: Scheduled multi maintenance plan
	When The user creates a new single item maintenance plan using the test set "<Single Set>"
	When The user creates a new <Plan Type> item maintenance plan using the test set "<Test Set>"
	Then The user validates the <Plan Type> item maintenance plan
	When The user Schedules a maintenance plan
	Then The user Releases the call
	Then The user Displays the call object and extracts the order number
	Then The user completed the call
	Then The user logs out

	Examples: 
	| Variable  | Plan Type | Test Set                               | Single Set                              |
	| AG01      | multi     | CreateAG01MultiItemMaintenancePlan     | CreateAG01SingleItemMaintenancePlan     |
	| AG01/Mech | multi     | CreateAG01MultiItemMaintenancePlanMECH | CreateAG01SingleItemMaintenancePlanMECH |
	| AG02      | multi     | CreateAG02MultiItemMaintenancePlan     | CreateAG02SingleItemMaintenancePlan     |
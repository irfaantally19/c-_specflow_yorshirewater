@STRATEGIC_PLANNING
Feature: Strategic_planning 
Create strategic maintenance planes and packages

Background: SAP is open and logged in
	Given SAP is open and logged in

Scenario Outline: Create a Maintenance Strategy 
	Given The strategic test data is set for a '<Test Set>'
	When The user adds a maintenance strategy called '<Strategy>'
	Then The user validates the maintenance strategy
	Then The user logs out

	Examples: 
	| Variable	          | Strategy  | Test Set                                      |
	| AG01 Time Based     | AAA012    | CreateAG01TimeBasedMaintenanceStrategy        |
	| AG01 Perf Based     | AAA013    | CreateAG01PerformanceBasedMaintenanceStrategy |
	| AG02 Time Based     | AAA014    | CreateAG02TimeBasedMaintenanceStrategy        |

Scenario Outline:  Create a Strategy Package
	Given The strategic test data is set for a '<Test Set>'
	When The user adds a strategy package using strategy '<Strategy>'
	Then The user validates the strategy package
	Then The user logs out

	Examples: 
	| Variable	          | Strategy  | Test Set                                      |
	| AG01 Time Based     | AAA012    | CreateAG01TimeBasedMaintenanceStrategy        |
	| AG01 Perf Based     | AAA013    | CreateAG01PerformanceBasedMaintenanceStrategy |
	| AG02 Time Based     | AAA014    | CreateAG02TimeBasedMaintenanceStrategy        |

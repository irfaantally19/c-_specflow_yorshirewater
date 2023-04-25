@TASK_LIST
Feature: CreateTaskList 
Create new task lists

Background: SAP is open and logged in
	Given SAP is open and logged in

#To create a general task list and add a general operation
Scenario Outline: Create A Task List 
	Given The test data is set for a '<Test Set>'
	When The user adds a general task list on group '<Group>' using strategy '<Strategy>'
	Then The user validates the general task list
	Then The user logs out

	Examples: 
	| Variable        | Group    | Strategy | Test Set                                 |
	| AG01 Time Based | I_ANALPZ | AAA012   | CreateAG01TimeBasedTaskListICA_1         |
	| AG01 Perf Based | I_ANALPZ | AAA013   | CreateAG01PerformanceBasedTaskListMECH_1 |
	| AG02 Time Based | I_ANALPZ | AAA014   | CreateAG02TimeBasedTaskListICA_1         |

#To add a second general operation to the previous task
Scenario Outline: Create Another Task List
	Given The test data is set for a '<Test Set>'
	When The user adds a general operation on group '<Group>' using strategy '<Strategy>'
	Then The user validates the general task list
	Then The user logs out

	Examples: 
	| Variable        | Group    | Strategy | Test Set                                 |
	| AG01 Time Based | I_ANALPZ | AAA012   | CreateAG01TimeBasedTaskListICA_2         |
	| AG01 Perf Based | I_ANALPZ | AAA013   | CreateAG01PerformanceBasedTaskListMECH_2 |
	| AG02 Time Based | I_ANALPZ | AAA014   | CreateAG02TimeBasedTaskListICA_2         |

@Maintenance_Plan
Feature: Maintenance Plan 
Create new maintenance plan

Background: SAP is open and logged in
	Given SAP is open and logged in

Scenario: Create single item, add multi item and amend item AG01 maintenance plan
	When The user creates a new single item maintenance plan using the test set "CreateAG01SingleItemMaintenancePlan"
	Then The user validates the single item maintenance plan
	When The user creates a new multi item maintenance plan using the test set "CreateAG01MultiItemMaintenancePlan"
	Then The user validates the multi item maintenance plan
	And The user logs out

Scenario: Create single item, add multi item and amend item AG01 maintenance plan MECH
	When The user creates a new single item maintenance plan using the test set "CreateAG01SingleItemMaintenancePlanMECH"
	Then The user validates the single item maintenance plan
	When The user creates a new multi item maintenance plan MECH using the test set "CreateAG01MultiItemMaintenancePlanMECH"
	Then The user validates the multi item maintenance plan
	When The user amends a multi items maintenance plan MECH using the test set "AmendAG01MultiItemMaintenancePlanMECH"
	Then The user validates the amendments to a multi item maintenance plan
	And The user logs out

Scenario: Create single item, add multi item and amend item AG02 maintenance plan
	When The user creates a new single item maintenance plan using the test set "CreateAG02SingleItemMaintenancePlan"
	Then The user validates the single item maintenance plan
	When The user creates a new multi item maintenance plan using the test set "CreateAG02MultiItemMaintenancePlan"
	Then The user validates the multi item maintenance plan
	When The user amends a multi items maintenance plan using the test set "AmendAG02MultiItemMaintenancePlan"
	Then The user validates the amendments to a multi item maintenance plan
	And The user logs out

Scenario: Create single item, add multi item and amend item AG03 maintenance plan
	When The user creates a new single item maintenance plan using the test set "CreateAG03SingleItemMaintenancePlan"
	Then The user validates the single item maintenance plan
	When The user creates a new multi item maintenance plan using the test set "CreateAG03MultiItemMaintenancePlan"
	Then The user validates the multi item maintenance plan
	When The user amends a multi items maintenance plan using the test set "AmendAG03MultiItemMaintenancePlan"
	Then The user validates the amendments to a multi item maintenance plan
	And The user logs out

Scenario: Create single item, add multi item and amend item AG04 maintenance plan
	When The user creates a new single item maintenance plan using the test set "CreateAG04SingleItemMaintenancePlan"
	Then The user validates the single item maintenance plan
	When The user creates a new multi item maintenance plan using the test set "CreateAG04MultiItemMaintenancePlan"
	Then The user validates the multi item maintenance plan
	When The user amends a multi items maintenance plan using the test set "AmendAG04MultiItemMaintenancePlan"
	Then The user validates the amendments to a multi item maintenance plan
	And The user logs out





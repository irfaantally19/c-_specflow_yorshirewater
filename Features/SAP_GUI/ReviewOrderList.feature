@Review_Order_List
Feature: ReviewOrderList
Review order lists for schedule tasks

Background: SAP is open and logged in
	Given SAP is open and logged in
	Given The user creates an order

Scenario: Review AG01 time based order list ACI
	When The user reviews an order list for: "AG01"
	Then The user validates the order list
	Then The user logs out


Scenario: Review AG01 performance based order list MECH
	When The user reviews an order list for: "AG01"
	Then The user validates the order list
	Then The user logs out

Scenario: Review AG02 time based order list ACI
	When The user reviews an order list for: "AG02"
	Then The user validates the order list
	Then The user logs out
Feature: MRS_Scheduling

Mrs Scheduling
Background: SAP is open and logged in
	Given SAP is open and logged in

#Scenario Outline:Scheduling Work Order in MRS
	#When The user set operation to SOP and completes planning using the test set "<Test Set>"
	#Then Schedule MRS work order
	#Examples: 
	#| Variable | Test Set                            |
	#| AG01     | AG01SOPAndCompletePlanningOperation |
	#| AG02     | AG02SOPAndCompletePlanningOperation |

	Scenario Outline:Block and unblock time for a technician in MRS
	When The user set operation to SOP and completes planning using the test set "<Test Set>"
	Then Block and unblock time for a technician
		
	Examples: 
	| Variable | Test Set                            |
	| AG01     | AG01SOPAndCompletePlanningOperation |
	| AG02     | AG02SOPAndCompletePlanningOperation |

	



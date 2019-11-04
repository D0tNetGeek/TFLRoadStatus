Feature: SeverityStatus
	In order to retrieve DisplayName, Severity and SeverityDescription
	As a Client
	I want to find the road status when correct road is passed

@statusNameDisplay
Scenario: Display Name should be displayed
	Given a valid road ID A2 is specified
	When the client is run
	Then the road 'displayName' should be displayed

@statusSeverityDisplay
Scenario: Diplay Severity
	Given a valid road ID A2 is specified
	When the client is run
	Then the road 'statusSeverity' should be diplayed as 'Road Status'

@statusSeverityDescriptionDisplay
Scenario: Display Severity Description
	Given a valid road ID A2 is specified
	When the client is run
	Then the road 'statusSeverityDescription' should b displayed as 'Road Status Description'

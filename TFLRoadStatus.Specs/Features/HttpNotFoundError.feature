Feature: HttpNotFoundError
	In order to retrieve HttpNotFoundError and ExitCode
	As a Client
	I want to get HttpStatusCode 404 when Non existing road is passed

@error404
Scenario: HttpError 404
	Given an invalid road ID A223 is specified
	When the client is run
	Then the application should return an infomative error
@error
Scenario: Non Zero Exit Code
	Given an invalid road ID A223 is specified
	When the client is run
	Then the application should exit with a non-zero System Error code

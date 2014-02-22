Feature: Publishing an event

Scenario: Publishing an event from service front end triggers a write to the data store
	Given I have a data store
	And a service front end
	When I publish an event via the service
	Then a write event is triggered

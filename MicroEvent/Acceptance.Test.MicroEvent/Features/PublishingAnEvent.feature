Feature: Publishing an event with a subscriber

Scenario: Subscriber to TestEvent is notified when a TestEvent is published
	Given I am subscribed to TestEvents
	When a TestEvent is published
	Then I am notified
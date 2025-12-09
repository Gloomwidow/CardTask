# CardTask
Microservice, that checks what actions are allowed with each card.

Each defined action uses custom-defined attributes to filter types of cards that are allowed or blocked from certain action.

Solution consists of 4 projects:

CheckCardActionsAPI - service that can be called to check what actions are allowed on card. Has one endpoint to check them.
CardActions - a class library containing sample card actions, as well as logic used to filter actions availability based on card details.
Cards - a class library with definitions of card details and a mock-up service for retrieving cards.
CardActions.Tests - contains unit tests that validate logic of actions filters for each action defined.

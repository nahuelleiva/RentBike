# RentBike
Simple desktop application that emulates a company that rent bikes. Depending on the rent type, it will be different charges:
* <b>Hourly rent:</b> if the client decides to rent bikes per hour, the company will charge $5 per hour for the rent.
* <b>Daily rent:</b> if the client decides to rent bikes per day, the charge will be of $20 per day.
* <b>Weekly rent:</b> otherwise, the client has the weekly option, and the charge will be of $60 per week.
In case client is with a family group, can get a 30% discount over the total rent

# Design
* <b>RentBikeModel:</b> the main class that has all the structure to persist data about the bike rents.
* <b>RentType:</b> an enum class that contains the different charges depending on the rent type.
* <b>RentBikeHelper:</b> acts like an mediator, interacting with the user and getting data from rents.
* <b>DBConnector:</b> communicates with the databes to persist data from rents.
* <b>Database:</b> An SQLite database to store information from rents.
![alt text](https://i.imgur.com/tFP0ULL.png)

# To run tests
* Clone the project from your Visual Studio IDE or download as a zip and then open it on Visual Studio.
* Make sure you have available the Test Explorer window. If not go to <b>Test</b> -> <b>Windows</b> -> <b>Test Explorer</b> to make it visible
* Then go to <b>Test</b> -> <b>Run</b> -> <b>All Tests</b> and see the results on your Test Explorer

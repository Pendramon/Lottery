# Lottery
A bottle cap lottery project for SEDC Expert C# Topics class

**This application is not production ready**
There were no unit tests written during the development of this application hence nothing is tested and anything could fail.
Also do note that this code base is pretty old and could and should definitely get a refactoring if anyone ever plans to use it.
The application project structure is nice and clean looking but the Repository and Unit of Work patterns implementations is an unecessary abstraction of Entity Framework's DbContext which essentially already implements the Unit of Work and Repository(DbSets) patterns.
And do note that there is little to no documentation done.


I developed and included a full backend solution to support a database, in a full decoupled scenario.  The WebApi is agnostic from the Application Core and the Database   through an interface , to ensure the even the API is fully decoupled from all the other components. 

Backend.Application- Class Library 

Contains all the application business logic. Uses the Command and Query Responsibility Segregation (CQRS) Pattern to manage all the operations supported.  

Backend.Common – Class Library 

 Contains common enumerations and values that are used across all the app. Like environment settings and/or configurations.  

Backend.Domain – Class Library 

Contains the modeling of all Database Objects in a POCO format. Can be reused to work with another RDBMS. The configuration for the POCO properties is built with a fluent configuration with Entity Framework Core.  

Backend.Infraestructure -Class Library 

Contains the infrastructure configuration like available databases, services and definition of entities in the RDBMS. This module configures the domain validation with a fluent language. Is independent from the Database Vendor and can be reused to support other vendors ( SQLite, Postgre, SQL Server , etc )


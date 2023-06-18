.NET Core REST API using CQRS implementation with raw SQL and DDD using Clean Architecture.
==============================================================

## Description
Sample .NET 7 REST API application implemented with basic [CQRS](https://docs.microsoft.com/en-us/azure/architecture/guide/architecture-styles/cqrs) approach and Domain Driven Design. The system is divided into logical layers. Basically this logical division consists of the API, Application, Domain and Infrastructure layers.


 ![projects_dependencies](img/clean_architecture.jpg)


## Steps to run application on local machine in windows 11 environment.

## docker run command to create a container with the latest SQL Server image. 
 docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Pass@word" -p 1433:1433 --name sqldata  -d mcr.microsoft.com/mssql/server:2019-latest
 
## Run the command "Add-Migration InitialCreate" and next step run the command  "Update-Database" to create the Database "MovementDb".
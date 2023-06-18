
CashFlowV1 is a system implemented in .NET 7 REST API using CQRS implementation with raw SQL and DDD using Clean Architecture.
==============================================================

## Description
CashFlowV1 is a system implemented in .NET 7 REST API application implemented with basic [CQRS](https://docs.microsoft.com/en-us/azure/architecture/guide/architecture-styles/cqrs) approach and Domain Driven Design. The system is divided into logical layers. Basically this logical division consists of the API, Application, Domain and Infrastructure layers.


 ![projects_dependencies](img/clean_architecture.jpg)


## Steps to run application on local machine in windows 11 environment.

## 1 - docker run command to create a container with the latest SQL Server image. 
 docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Pass@word" -p 1433:1433 --name sqldata  -d mcr.microsoft.com/mssql/server:2019-latest
 
## 2 - Run the command "Add-Migration InitialCreate" to initialze the migration function.

## 3 - Open the project in Visual Studio 2022 with the administrator user and run it to create the Database "MovementDb with some data. 

## 4 - The system will create a page using the Swagger tool for consuming the services.
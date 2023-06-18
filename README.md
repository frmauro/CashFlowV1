Sample .NET Core REST API CQRS implementation with raw SQL and DDD using Clean Architecture.
==============================================================

## Description
Sample .NET 7 REST API application implemented with basic [CQRS](https://docs.microsoft.com/en-us/azure/architecture/guide/architecture-styles/cqrs) approach and Domain Driven Design.


 ![projects_dependencies](docs/clean_architecture.jpg)


# command docker run to sql server
 docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Pass@word" -p 1433:1433 --name sqldata  -d mcr.microsoft.com/mssql/server:2019-latest

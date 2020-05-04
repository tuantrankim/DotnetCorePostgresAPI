https://medium.com/faun/asp-net-core-entity-framework-core-with-postgresql-code-first-d99b909796d7
### Install PostGres with pgadmin
https://www.enterprisedb.com/downloads/postgres-postgresql-downloads
### Add Nuget package
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools
Npgsql.EntityFrameworkCore.PosgreSQL
### Code first
ConfigureService
Configure DatabaseConnection
Create Models
Create ApplicationDBContext
### Run in Package Manager Console
PM> enable-migrations
PM> add-migration initial
PM> update-database
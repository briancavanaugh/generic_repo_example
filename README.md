# generic_repo_example

This is a .NET 9 example project demonstrating a generic repository pattern with Dapper for data access.

## Prerequisites

- .NET 9 SDK
- SQL Server LocalDB (comes with Visual Studio or can be installed separately)

## Projects

- **Infrastructure**: Class library containing the generic repository implementation and data models
- **DbMigration**: Console application for database migrations using DbUp
- **dapper-ddd-repo**: Main console application demonstrating the usage of the generic repository

## How to run

1. Run DbMigration project first. This will create the database and tables using MSSQLLocalDB:
   ```bash
   dotnet run --project DbMigration
   ```

2. After that, run the dapper-ddd-repo main project which is a simple console app:
   ```bash
   dotnet run --project dapper-ddd-repo
   ```

## Configuration

Connection strings are configured in `appsettings.json` files in each project. By default, they use SQL Server LocalDB:
```json
{
  "ConnectionStrings": {
    "MainDb": "Data Source=(localdb)\\mssqllocaldb;Integrated Security=true;Initial Catalog=dapper-examples;"
  }
}
```

## Technologies Used

- .NET 9
- Dapper 2.1.66 (micro ORM)
- DbUp 6.0.0 (database migrations)
- Microsoft.Data.SqlClient 5.2.2 (SQL Server data provider)

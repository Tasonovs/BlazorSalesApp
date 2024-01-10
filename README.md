## Blazor WebAssembly architecture example 

Welcome to the Blazor sales app for doors and windows!

The main effort in this project was put into the server side. Were utilized:
* Onion architecture
* Separate projects for UI and API
* CQRS pattern
* Shared communication models for Server and Client
* And some experience-based utilities that will always find use in the project

Also worked with Blazor for the first time and had mixed impressions :) .


### Built With

* ASP.NET Core 8.0
* EF Core with MSSQL database
* Automapper
* FluentValidation
* MediatR (for CQRS pattern)
* Blazor WebAssembly
* MudBlazor (UI library)


## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.


### Installation

1. Create `BlazorSalesApp.Infrastructure\appsettings.migration.Development.json` and `BlazorSalesApp.Api\appsettings.Development.json` with the same content and connection string to database
   ```json
    {
        "ConnectionStrings": {
            "DefaultConnection": "Server..."
        }
    }
   ```
2. Update a database
   ```sh
   \src\BlazorSalesApp.Infrastructure> dotnet ef database update
   ```
3. Run the Api project
   ```sh
   \src\BlazorSalesApp.Api> dotnet run -lp=https
   ```
4. Run the Ui project
   ```sh
   \src\BlazorSalesApp.Api> dotnet run -lp=https
   ```

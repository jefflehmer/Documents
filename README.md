# ForMoreMoney Documents

## Overview

This is a "Documents" service for a fictitious company called For-More-Money.  It is a showcase for how I would create a microservice that would handle upload, download, and management of company documents.  It will start out as a simple service but may grow in complexity over time.

## Development Notes

Chose the K8S/Docker project template because...
The documents microservice provides an API for document management.
Put source code project under "src" folder and test project under "test" folder.  Possibly help in future build pipeline to have consistent folder management across all microservice projects.
Currently calling service methods directly in controller but want to execute them through individual commands/queries.

### Architecture

This service follows a ES/CQRS implementation.  It is backed by a SQL database with only a single table.  It sends update on the Azure Service Bus so that the Orders service (quadpay-api project) will update its read db.

The service also relies heavily on the Auth0 Management API to create/update customers.

### Testing

asdf

### Choice of Database

For a Document Service the clear choice would be a No-SQL database.  I will probably implement with EntityFramework (EFx) for my first iteration but that doesn't have the greatest "thread-safe" reputation.

### Transient vs Scoped

The choice of which lifetime to give to each service is very important...

### CQRS

Separated commands and queries into separate folders in a vague attempt at directing an eventual CQRS strategy.

### AppSettings

Explique differences between appsettings.json and appsettings.Development, etc...

### Configuration

Secrets configuration is stored in Azure Key Vault per our configuration approach.  If you wish to override them locally, here is a base layout of the secrets.json file to use for local configuration in the project.



```json
{
 "ApplicationInsights": {
    "InstrumentationKey": "guid"
  },
  "ConnectionStrings": {
    "EventStore": string,
    "SqlServer": string,
    "ServiceBus": string
  },
  "Auth0ManagementApi": {
    "Audience": string,
    "Domain": string,
    "ClientId": string,
    "ClientSecret": string
  },
}
```

### Testing

Ensure

### Potential Future Changes

Handlers for specific document types
StyleCop
Swagger
Logger
OAuth v2
Support for CancellationToken in controllers-actions to stop a long running process
Telemetry
Saved Postman queries
PUT vs POST

Technologies that would be nice to incorporate:
  GraphQL
  EventStore
  Mediatr
  No-SQL

# ForMoreMoney Documents

## Overview

This is a "Documents" service for a fictitious company called For-More-Money.  It is a showcase for how I would create a microservice that would handle upload, download, and management of company documents.  It will start out as a simple service but may grow in complexity over time.

## Development Notes

Was able to create all of the infrastructure and core implementations for a "documents" service over the weekend with 5-6 actual hours of uninterrupted development time.  Still need to implement the "Save" method and add real database support.

Did not yet choose a database for persistence of the documents.  Used a local folder while fleshing out the rest of the functionality.  For a Document Service the clear choice would be a No-SQL database in Azure/AWS.  I could implement it with EntityFramework (EFx) but that doesn't have the greatest "thread-safe" reputation.

Currently calling service methods directly in controller but want to execute them through individual commands/queries.  Hopefully using a Mediatr.

Chose to register the "Documents" service as Scoped rather than as Transient or Singleton.  This should give the optimal performance and safety.

Chose the K8S/Docker project template because one of the requirements was to be able to "handle multiple concurrent requests".  Having the ability to deploy multiple servers automatically on demand through K8S/Docker will give this service the ability to handle extreme cases.

Put source code project under "src" folder and test project under "test" folder.  Possibly help in future build pipeline to have consistent folder management across all microservices.  This kind of a service rarely exists alone.

This intention of this service is to follow an ES/CQRS implementation. Separated commands and queries into separate folders in a vague attempt at directing an eventual CQRS strategy.

## Testing

Testing is implemented using xUnit, FakeItEasy, and Shouldly.  The tests are not currently extensive in that they only support one test for each endpoint.  They also assume the local file is a repository rather than a database.

Testing is broken into three categories.  Still implementing tests so there aren't many in there yet.
- E2E - End-to-End
- Integration
- Unit

## Potential Future Changes

1. Work with a cloud-based No-SQL database rather than the local file system
2. Improved error handling and error feedback
3. Swagger
4. Logger
5. StyleCop
6. Telemetry
7. OAuth v2
8. Compress files before storing
9. How to deal with large files that could take up a lot of memory
10. Add handlers for specific document types
11. Support for CancellationToken in controllers-actions to stop a long running process
12. Saved Postman queries

## Technologies that would be nice to incorporate:
 - GraphQL
 - EventStore
 - CQRS - Command Query Responsibility Separation
 - Mediatr
 - No-SQL

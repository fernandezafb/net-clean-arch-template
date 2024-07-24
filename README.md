# Clean Architecture Template

What's included in the template?

- SharedKernel project with common Domain-Driven Design abstractions.
- Domain layer with a sample entity.
- Application layer with abstractions for:
    - CQRS
    - Caching
    - Cross-cutting concerns (logging, caching, validation)
- Infrastructure layer with:
    - SQL, EF Core, Caching, Repositories
- Dockerfile and docker-compose for running the application in a container: includes Postgresql for the DB and Redis for the caching layer.
- Testing projects
    - Unit testing
    - Integration testing
    - Functional testing
    - Architecture testing

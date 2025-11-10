# Postgres in TestContainer example

## Starting the application independently

### Start Postgres

```shell
docker run --rm -e POSTGRES_DB=specmatic_uuid_db -e POSTGRES_USER=dotnet -e POSTGRES_PASSWORD=dotNet1234 -p 5432:5432 postgres:17
```

### Start the Service

```shell
dotnet run
```

## Running contract tests programmatically with test containers

```shell
dotnet clean
dotnet restore
dotnet build
dotnet test
```

The test report should appear in "specmatic-uuid-api-test/build/report/specmatic/index.html" 

## Running the application, postgres and contract tests via Docker Compose

```shell
docker compose --profile test up --abort-on-container-exit
```
using DotNet.Testcontainers.Builders;
using Testcontainers.PostgreSql;

namespace specmatic_uuid_api_test.contract
{
    public class PostgresTestContainer : IAsyncLifetime
    {
        private readonly PostgreSqlContainer _postgresContainer;

        public string ConnectionString => _postgresContainer.GetConnectionString();

        public PostgresTestContainer()
        {
            _postgresContainer = new PostgreSqlBuilder()
                .WithImage("postgres:17")
                .WithDatabase("specmatic_uuid_db")
                .WithUsername("dotnet")
                .WithPassword("dotNet1234")
                .WithPortBinding(5432, 5432) // Bind container port 5432 to host port 5432
                .WithWaitStrategy(Wait.ForUnixContainer().UntilExternalTcpPortIsAvailable(5432))
                .WithCleanUp(true) // Auto-remove container after tests
                .Build();
        }

        public async Task InitializeAsync()
        {
            await _postgresContainer.StartAsync().ConfigureAwait(true);
            Console.WriteLine($"PostgreSQL Test Container started at: {_postgresContainer.GetConnectionString()}");
        }

        public async Task DisposeAsync()
        {
            await _postgresContainer.DisposeAsync();
            Console.WriteLine("PostgreSQL Test Container stopped and removed.");
        }
    }
}
using Dapper;
using Npgsql;
using System.Data;

namespace TechChallenge.Tests.Integration.Fixtures
{
    public class DatabaseFixture : IDisposable
    {
        public IDbConnection Connection { get; private set; }

        public DatabaseFixture()
        {
            var connectionString = "Host=localhost;Port=5432;Username=testuser;Password=102030;Database=testdb;Include Error Detail=true";
            Connection = new NpgsqlConnection(connectionString);
            Connection.Open();

            RecreateDatabase().Wait();
        }

        private async Task RecreateDatabase()
        {
            var script = File.ReadAllText("Setup/setup.sql");
            await Connection.ExecuteAsync(script);
        }

        public void Dispose()
        {
            var script = File.ReadAllText("Setup/drop.sql");
            Connection.Execute(script);
            Connection.Dispose();
        }
    }
}

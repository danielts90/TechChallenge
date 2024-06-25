using Dapper;
using Npgsql;
using System.Data;

namespace TechChallenge.Tests.Integration.Fixtures
{
    public class DatabaseFixture : IDisposable
    {
        public IDbConnection? Connection { get; private set; }

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
            
            if(Connection is IDbConnection)
                await Connection.ExecuteAsync(script);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && Connection is not null)
            {
                var dropScript = File.ReadAllText("Setup/drop.sql");
                Connection.Execute(dropScript);
                Connection.Dispose();
                Connection = null;
            }
        }
    }
}

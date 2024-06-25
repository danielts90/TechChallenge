using TechChallenge.Tests.Integration.Fixtures;

namespace TechChallenge.Tests.Integration.Collection
{
    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture> { }
}

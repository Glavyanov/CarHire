namespace CarHire.UnitTests
{
    public class InMemoryDbContext
    {
        private readonly SqliteConnection sqliteConnection;

        private readonly DbContextOptions<ApplicationDbContext> dbContextOptions;

        public InMemoryDbContext()
        {
            sqliteConnection = new SqliteConnection("Filename=:memory:");
            sqliteConnection.Open();

            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(sqliteConnection)
                .Options;

            using var context = new ApplicationDbContext(dbContextOptions);

            context.Database.EnsureCreated();
        }

        public ApplicationDbContext CreateContext() => new ApplicationDbContext(dbContextOptions);

        public void Dispose() => sqliteConnection.Dispose();
    }
}

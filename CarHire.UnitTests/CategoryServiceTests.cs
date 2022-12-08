namespace CarHire.UnitTests
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();

            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<ICategoryService, CategoryService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            await SeedDbAsync(repo!);
            
        }

        [Test]
        [TestCase(100)]
        [TestCase(101)]
        public async Task ExistsbyIdAsyncMethodShouldReturnTrue (int categoryId)
        {
            var categoryService = serviceProvider.GetService<ICategoryService>();

            Assert.That(await categoryService!.ExistsbyIdAsync(categoryId), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
            
        }

        private static async Task SeedDbAsync(IRepository repo)
        {
            List<Category> categories = new()
            {
                new Category()
                {
                    Id = 100,
                    Name = "Passenger"
                },
                new Category()
                {
                    Id = 101,
                    Name = "Light comercial"
                }
            };

            await repo.AddRangeAsync(categories);
            await repo.SaveChangesAsync();
        }
    }
}
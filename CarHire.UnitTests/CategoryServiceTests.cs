namespace CarHire.UnitTests
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;
        private ICategoryService categoryService;

        [SetUp]
        public async Task SetUp()
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

            categoryService = serviceProvider.GetService<ICategoryService>()!;
        }

        [Test]
        public void Ctor_CategoryServiceShouldWorkCorrectly() => Assert.That(categoryService, Is.Not.Null);

        [Test]
        [TestCase(100)]
        [TestCase(101)]
        public async Task ExistsbyIdAsyncMethodShouldReturnTrue(int categoryId) =>
            Assert.That(await categoryService.ExistsbyIdAsync(categoryId), Is.True);

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(10_000_000)]
        public async Task ExistsbyIdAsyncMethodShouldReturnFalse(int categoryId) =>
            Assert.That(await categoryService!.ExistsbyIdAsync(categoryId), Is.False);

        [Test]
        public async Task GetCategoriesAsyncMethodShouldReturnCorrectCount() =>
            Assert.That((await categoryService.GetCategoriesAsync()).Count, Is.EqualTo(6));

        [Test]
        public async Task GetCategoriesAsyncShouldReturnCorrectType() =>
            Assert.IsInstanceOf<CategoryHomeModel>((await categoryService.GetCategoriesAsync()).FirstOrDefault());

        [Test]
        public async Task GetCategoriesAsyncShouldReturnCorrectCollectionOfType() =>
            Assert.IsInstanceOf<List<CategoryHomeModel>>(await categoryService.GetCategoriesAsync());

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
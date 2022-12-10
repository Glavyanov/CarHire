namespace CarHire.UnitTests
{
    [TestFixture]
    public class CommentServiceTests
    {
        private InMemoryDbContext dbContext;
        private ServiceProvider serviceProvider;
        private ICommentService commentService;

        [SetUp]
        public async Task SetUp()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<ICommentService, CommentService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            await SeedDbAsync(repo!);

            commentService = serviceProvider.GetService<ICommentService>()!;
        }

        [Test]
        [TestCase("63B0E3A2-8999-4CE1-B741-C86E548D3529")]
        [TestCase("89E83A6E-4492-45BD-B1B1-9821B518E0E1")]
        public async Task ExistByIdAsyncMethodShouldReturnTrue(string commentId) =>
            Assert.That(await commentService.ExistByIdAsync(commentId), Is.True);

        [Test]
        [TestCase("AD163FA5-4ED9-4B4A-B73C-5315B2D8E58B")]
        public async Task ExistByIdAsyncMethodShouldReturnFalseWhenCommentIsDeleted(string commentId) =>
            Assert.That(await commentService.ExistByIdAsync(commentId), Is.False);

        [Test]
        [TestCase("foo")]
        public async Task ExistByIdAsyncMethodShouldReturnFalseWhenCommentIsNotExist(string commentId) =>
            Assert.That(await commentService.ExistByIdAsync(commentId), Is.False);

        [Test]
        [TestCase("63B0E3A2-8999-4CE1-B741-C86E548D3529")]
        [TestCase("AD163FA5-4ED9-4B4A-B73C-5315B2D8E58B")]
        public async Task DeleteByIdAsyncMethodShouldWorkCorrect(string commentId)
        {
            await commentService.DeleteByIdAsync(commentId);

            Assert.That(await commentService.ExistByIdAsync(commentId), Is.False);
        }

        [Test]
        public async Task GetAllAsyncShouldReturnCorrectCount()
        {
            IEnumerable<CommentViewModel> commentsCollection = await commentService.GetAllAsync();

            Assert.That(commentsCollection.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetAllAsyncShouldReturnCorrectCollectionOfType()
        {
            IEnumerable<CommentViewModel> commentsCollection = await commentService.GetAllAsync();

            Assert.IsInstanceOf<IEnumerable<CommentViewModel>>(commentsCollection);
        }

        [Test]
        public async Task GetAllAsyncShouldReturnCorrectEmptyCollection()
        {
            await commentService.DeleteByIdAsync("63B0E3A2-8999-4CE1-B741-C86E548D3529");
            await commentService.DeleteByIdAsync("89E83A6E-4492-45BD-B1B1-9821B518E0E1");

            IEnumerable<CommentViewModel> commentsCollection = await commentService.GetAllAsync();

            Assert.That(commentsCollection.Count(), Is.Zero);
        }

        [Test]
        public async Task CreateCommentAsyncShouldReturnCorrectCount()
        {
            CommentHomeModel model = new()
            {
                VehicleId = "779BD522-2646-40B0-90A9-AF4DDB9551A5",
                UserName = "Jane",
                Description = "Hello from Jane",

            };

            await commentService.CreateCommentAsync(model);

            Assert.That((await commentService.GetAllAsync()).Count(), Is.EqualTo(3));
        }

        [Test]
        public void CreateCommentAsyncShouldThrowArgumentException()
        {
            CommentHomeModel model = new()
            {
                VehicleId = "foo",
                UserName = "Jane",
                Description = "Hello from Jane",

            };

            Assert.CatchAsync<ArgumentException>(async () => await commentService.CreateCommentAsync(model));

            Assert.That(Assert.CatchAsync<ArgumentException>(async () => await commentService.CreateCommentAsync(model)).Message, Is.EqualTo("The renter is not exist!"));
        }

        [Test]
        public async Task GetAllCommentsByVehicleIdAsyncShouldReturnCorrectCount()
        {
            CommentExposeModel model =
                await commentService.GetAllCommentsByVehicleIdAsync("779BD522-2646-40B0-90A9-AF4DDB9551A5");

                Assert.That(model.Comments.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetAllCommentsByVehicleIdAsyncShouldReturnCorrectCollectionOfType()
        {
            CommentExposeModel model =
                await commentService.GetAllCommentsByVehicleIdAsync("779BD522-2646-40B0-90A9-AF4DDB9551A5");

            Assert.IsInstanceOf<IEnumerable<CommentByVehicleModel>>(model.Comments);
        }

        [Test]
        public async Task GetAllCommentsByVehicleIdAsyncShouldReturnCorrectType()
        {
            CommentExposeModel model =
                await commentService.GetAllCommentsByVehicleIdAsync("779BD522-2646-40B0-90A9-AF4DDB9551A5");

            Assert.IsInstanceOf<CommentExposeModel>(model);
        }

        [Test]
        public async Task GetAllCommentsByVehicleIdAsyncShouldReturnCorrectImage()
        {
            CommentExposeModel model =
                await commentService.GetAllCommentsByVehicleIdAsync("779BD522-2646-40B0-90A9-AF4DDB9551A5");
            string image = "https://mir-s3-cdn-cf.behance.net/project_modules/1400/9a84ff95800693.5e9ff770404b5.jpg";

            Assert.That(model.ImageUrl, Is.EqualTo(image));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();

        }

        private static async Task SeedDbAsync(IRepository repository)
        {
            List<Comment> comments = new()
            {
                new()
                {
                    Id = new Guid("63b0e3a2-8999-4ce1-b741-c86e548d3529"),
                    Date = DateTime.Now,
                    VehicleId = new Guid("779bd522-2646-40b0-90a9-af4ddb9551a5"),
                    RenterId = new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                    Description = "First comment in memory DB",
                    IsDeleted = false
                },
                new()
                {
                    Id = new Guid("89e83a6e-4492-45bd-b1b1-9821b518e0e1"),
                    Date = DateTime.Now,
                    VehicleId = new Guid("779bd522-2646-40b0-90a9-af4ddb9551a5"),
                    RenterId = new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                    Description = "Second comment in memory DB",
                    IsDeleted = false
                },
                new()
                {
                    Id = new Guid("ad163fa5-4ed9-4b4a-b73c-5315b2d8e58b"),
                    Date = DateTime.Now,
                    VehicleId = new Guid("779bd522-2646-40b0-90a9-af4ddb9551a5"),
                    RenterId = new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                    Description = "Third comment in memory DB",
                    IsDeleted = true
                },
            };

            await repository.AddRangeAsync(comments);

            Order order = new()
            {
                Id = new Guid("e9a70270-41bd-4da9-8a7f-d78f3a4bb26a"),
                VehicleId = new Guid("779bd522-2646-40b0-90a9-af4ddb9551a5"),
                IsDeleted = false,
                RenterId = new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                TotalDays = 1,
                Price = 250,
                TotalPriceWithDiscounts = 250,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,

            };

            await repository.AddAsync(order);

            await repository.SaveChangesAsync();

        }
    }
}

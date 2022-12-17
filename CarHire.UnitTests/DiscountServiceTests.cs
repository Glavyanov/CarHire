using CarHire.Core.Models.Discount;

namespace CarHire.UnitTests
{
    [TestFixture]
    public class DiscountServiceTests
    {
        private InMemoryDbContext dbContext;
        private ServiceProvider serviceProvider;
        private IDiscountService discountService;

        [SetUp]
        public async Task SetUp()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IDiscountService, DiscountService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            await SeedDbAsync(repo!);

            discountService = serviceProvider.GetService<IDiscountService>()!;
        }

        [Test]
        public async Task ExistsbyIdAsyncShouldReturnTrue() =>
            Assert.That(
                await discountService.ExistsbyIdAsync("27A72655-B683-411F-A0D0-BCB9E2DAB90C"),Is.True);

        [Test]
        [TestCase("foo")]
        [TestCase("")]
        [TestCase("  ")]
        public async Task ExistsbyIdAsyncShouldReturnFalse(string id) =>
            Assert.That(await discountService.ExistsbyIdAsync(id), Is.False);

        [Test]
        [TestCase("B544D7B1-7F17-4213-9823-90E82C66DB2E", "27A72655-B683-411F-A0D0-BCB9E2DAB90C")]
        [TestCase("E0DEC8E7-92C7-441E-AD75-55F8234FAD59", "27A72655-B683-411F-A0D0-BCB9E2DAB90C")]
        public async Task ExistDiscountOnVehicleAsyncShouldReturnTrue(string vehicleId, string discountId) =>
            Assert.That(
                await discountService.ExistDiscountOnVehicleAsync(vehicleId, discountId), Is.True);

        [Test]
        [TestCase("779BD522-2646-40B0-90A9-AF4DDB9551A5", "27A72655-B683-411F-A0D0-BCB9E2DAB90C")]
        [TestCase("foo", "27A72655-B683-411F-A0D0-BCB9E2DAB90C")]
        public async Task ExistDiscountOnVehicleAsyncShouldReturnFalse(string vehicleId, string discountId) =>
            Assert.That(
                await discountService.ExistDiscountOnVehicleAsync(vehicleId, discountId), Is.False);

        [Test]
        [TestCase("779BD522-2646-40B0-90A9-AF4DDB9551A5", "27A72655-B683-411F-A0D0-BCB9E2DAB90C")]
        [TestCase("F31DB974-2830-410D-B435-66844298846A", "27A72655-B683-411F-A0D0-BCB9E2DAB90C")]

        public async Task AddDiscountToVehicleAsyncShouldWorkCorrect(string vehicleId, string discountId)
        {
            await discountService.AddDiscountToVehicleAsync(vehicleId, discountId);

            bool result = await discountService.ExistDiscountOnVehicleAsync(vehicleId, discountId);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task GetAllAsyncShouldReturnCorrectType() =>
            Assert.IsInstanceOf<IEnumerable<DiscountHomeModel>>(await discountService.GetAllAsync());

        [Test]
        public async Task GetAllAsyncShouldReturnCorrectCount() =>
            Assert.That((await discountService.GetAllAsync()).Count(), Is.EqualTo(1));

        [Test]
        public async Task GetAllAsyncShouldReturnCorrectItem()
        {
            var discount = (await discountService.GetAllAsync()).FirstOrDefault();

            Assert.Multiple(() =>
            {
                Assert.That(discount!.Id, Is.EqualTo("27A72655-B683-411F-A0D0-BCB9E2DAB90C"));
                Assert.That(discount.Name, Is.EqualTo("Summer"));
                Assert.That(discount.DiscountSize, Is.EqualTo(26));
                Assert.That(discount.ExpireOn, Is.EqualTo(new DateTime(2023, 9, 1, 7, 47, 0)));
            });
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private static async Task SeedDbAsync(IRepository repo)
        {
            Discount summerDiscount = new()
            {
                Id = new Guid("27a72655-b683-411f-a0d0-bcb9e2dab90c"),
                Name = "Summer",
                DiscountSize = 26,
                ExpireOn = new DateTime(2023, 9, 1, 7, 47, 0),
                VehicleDiscounts = new List<VehicleDiscount>()
                {
                    new VehicleDiscount()
                    {
                        DiscountId = new Guid("27a72655-b683-411f-a0d0-bcb9e2dab90c"),
                        VehicleId = new Guid("b544d7b1-7f17-4213-9823-90e82c66db2e")
                    },
                    new VehicleDiscount()
                    {
                        DiscountId = new Guid("27a72655-b683-411f-a0d0-bcb9e2dab90c"),
                        VehicleId = new Guid("e0dec8e7-92c7-441e-ad75-55f8234fad59")
                    }
                }

            };

            await repo.AddAsync(summerDiscount);
            await repo.SaveChangesAsync();
        }
    }
}

namespace CarHire.UnitTests
{
    [TestFixture]
    public class RentServiceTests
    {
        private InMemoryDbContext dbContext;
        private ServiceProvider serviceProvider;
        private IRentService rentService;

        [SetUp]
        public async Task SetUp()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IRentService, RentService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            await SeedDbAsync(repo!);

            rentService = serviceProvider.GetService<IRentService>()!;
        }

        [Test]
        public async Task GetVehiclesByRenterIdAsyncShouldReturnCorrectType()
        {
            List<VehicleHomeModel> vehicles =
                await rentService.GetVehiclesByRenterIdAsync("27fba6ae-8175-4484-9b0d-917d6b32c851");

            Assert.IsInstanceOf<List<VehicleHomeModel>>(vehicles);
        }

        [Test]
        public async Task GetVehiclesByRenterIdAsyncShouldReturnCorrectCount()
        {
            List<VehicleHomeModel> vehicles =
                await rentService.GetVehiclesByRenterIdAsync("27fba6ae-8175-4484-9b0d-917d6b32c851");

            Assert.That(vehicles, Has.Count.EqualTo(2));
        }

        [Test]
        public async Task GetVehiclesByRenterIdAsyncShouldReturnCorrectVehicles()
        {
            List<VehicleHomeModel> vehicles =
                await rentService.GetVehiclesByRenterIdAsync("27fba6ae-8175-4484-9b0d-917d6b32c851");

            Assert.Multiple(() =>
            {
                Assert.That(vehicles.Where(x => x.Id == "F31DB974-2830-410D-B435-66844298846A").ToList(), Has.Count.EqualTo(1));
                Assert.That(vehicles.Where(x => x.Id == "779BD522-2646-40B0-90A9-AF4DDB9551A5").ToList(), Has.Count.EqualTo(1));
            });
        }

        [Test]
        [TestCase("F31DB974-2830-410D-B435-66844298846A")]
        [TestCase("779BD522-2646-40B0-90A9-AF4DDB9551A5")]
        public async Task GetVehicleRentByIdAsyncShouldReturnCorrectType(string vehicleId) =>
            Assert.IsInstanceOf<VehicleRentModel>(await rentService.GetVehicleRentByIdAsync(vehicleId));

        [Test]
        public async Task GetVehicleRentByIdAsyncShouldReturnCorrectVehicleWithDiscount()
        {
            VehicleRentModel vehicle =
                await rentService.GetVehicleRentByIdAsync("779BD522-2646-40B0-90A9-AF4DDB9551A5");

            Assert.Multiple(() =>
            {
                Assert.That(vehicle.Id, Is.EqualTo("779BD522-2646-40B0-90A9-AF4DDB9551A5"));
                Assert.That(vehicle.PricePerDay, Is.EqualTo(125M));
                Assert.That(vehicle.ImageUrl, Is.EqualTo("https://mir-s3-cdn-cf.behance.net/project_modules/1400/9a84ff95800693.5e9ff770404b5.jpg"));
                Assert.That(vehicle.IsRented, Is.True);
                Assert.That(vehicle.DrivingLicense, Is.Null);
            });
        }

        [Test]
        public async Task GetVehicleRentByIdAsyncShouldReturnCorrectVehicleWithoutDiscount()
        {
            VehicleRentModel vehicle =
                await rentService.GetVehicleRentByIdAsync("F31DB974-2830-410D-B435-66844298846A");

            Assert.Multiple(() =>
            {
                Assert.That(vehicle.Id, Is.EqualTo("F31DB974-2830-410D-B435-66844298846A"));
                Assert.That(vehicle.PricePerDay, Is.EqualTo(250M));
                Assert.That(vehicle.ImageUrl, Is.EqualTo("https://s1.cdn.autoevolution.com/images/news/gallery/chevrolet-chevelle-ss-black-panther-looks-wide-and-then-some_3.jpg"));
                Assert.That(vehicle.IsRented, Is.True);
                Assert.That(vehicle.DrivingLicense, Is.Null);
            });
        }

        [Test]
        public async Task GetRenterByIdAsyncShouldReturnCorrectType() =>
            Assert.IsInstanceOf<RenterHomeModel>(
                await rentService.GetRenterByIdAsync("0D5E7B0B-F3ED-4026-BEC8-90EBC90019F8"));

        [Test]
        public async Task GetRenterByIdAsyncShouldReturnCorrectRenter()
        {
            RenterHomeModel model = await rentService.GetRenterByIdAsync("0D5E7B0B-F3ED-4026-BEC8-90EBC90019F8");

            Assert.That(model.Id, Is.EqualTo("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"));
        }

        [Test]
        public async Task ExistsByApplicationUserIdAsyncShouldReturnTrue() => Assert.That( 
            await rentService.ExistsByApplicationUserIdAsync("27fba6ae-8175-4484-9b0d-917d6b32c851"), Is.True);

        [Test]
        [TestCase("foo")]
        [TestCase(null)]
        [TestCase("27fba6ae-8175-4484-9b0d-917d6b32C851", Description = "Valid id, but some chars are in upper case")]
        [TestCase("27fba6ае-8175-4484-9b0d-917d6b32с851",  Description = "Valid id, but some chars are in cyrilic")]
        [TestCase("27FBA6AE-8175-4484-9B0D-917D6B32C851")]
        [TestCase("")]
        public async Task ExistsByApplicationUserIdAsyncShouldReturnFalse(string? id) =>
            Assert.That(await rentService.ExistsByApplicationUserIdAsync(id), Is.False);



        [Test]
        public async Task DeleteOrderAsyncShouldReturnTrue()
        {
            bool isDeleted =
                await rentService.DeleteOrderAsync(vehicleId: "779bd522-2646-40b0-90a9-af4ddb9551a5",
                                                   applicationUserId: "27fba6ae-8175-4484-9b0d-917d6b32c851");
            Assert.That(isDeleted, Is.True);
        }

        [Test]
        public async Task DeleteOrderAsyncShouldReturnFalseWhenOrderIsDeleted()
        {
            bool isDeleted =
                await rentService.DeleteOrderAsync(vehicleId: "82ea3f6a-4782-41d0-bc2d-6ca2f7f9acea",
                                                   applicationUserId: "27fba6ae-8175-4484-9b0d-917d6b32c851");
            Assert.That(isDeleted, Is.False);
        }

        [Test]
        public async Task DeleteOrderAsyncShouldReturnFalseWhenUserIsNotExist()
        {
            bool isDeleted =
                await rentService.DeleteOrderAsync(vehicleId: "82ea3f6a-4782-41d0-bc2d-6ca2f7f9acea",
                                                   applicationUserId: "foo");
            Assert.That(isDeleted, Is.False);
        }
        [Test]
        public async Task DeleteOrderAsyncShouldReturnFalseWhenVehicleIsNotExist()
        {
            bool isDeleted =
                await rentService.DeleteOrderAsync(vehicleId: "611fe97b-c6df-46e8-84fb-81a15f0138c7",
                                                   applicationUserId: "27fba6ae-8175-4484-9b0d-917d6b32c851");
            Assert.That(isDeleted, Is.False);
        }

        [Test]
        [TestCase(-0)]
        [TestCase(0.1)]
        [TestCase(249.999)]
        [TestCase(-249.999)]
        [TestCase(+249.9999999999)]
        public void CreateRenterAsyncShouldThrowArgumentExceptionWithVehicleWithoutDiscount(decimal price)
        {
            RenterHomeModel model = new()
            {
                Id = "foo",
                ApplicationUserId= "foo",
                DrivingLicenseNumber = "foo",
                VehicleId = "F31DB974-2830-410D-B435-66844298846A",
                HiredCarPricePerDay = price
            };

            var ex = Assert.CatchAsync<ArgumentException>(async () => await rentService.CreateRenterAsync(model));
            Assert.That(ex.Message, Is.EqualTo("The price is manipulated!"));
        }

        [Test]
        [TestCase(-0)]
        [TestCase(0.1)]
        [TestCase(-0.1)]
        [TestCase(124.99999999)]
        [TestCase("124.99999999")]
        [TestCase(0x7C)]
        public void CreateRenterAsyncShouldThrowArgumentExceptionWithVehicleWithDiscount(decimal price)
        {
            RenterHomeModel model = new()
            {
                Id = "foo",
                ApplicationUserId = "foo",
                DrivingLicenseNumber = "foo",
                VehicleId = "779BD522-2646-40B0-90A9-AF4DDB9551A5",
                HiredCarPricePerDay = price
            };

            var ex = Assert.CatchAsync<ArgumentException>(async () => await rentService.CreateRenterAsync(model));
            Assert.That(ex.Message, Is.EqualTo("The price is manipulated!"));
        }

        [Test]
        public async Task CreateRenterAsyncShouldWorkCorrect()
        {
            var repo = serviceProvider.GetService<IRepository>();

            RenterHomeModel model = new()
            {
                ApplicationUserId = "44569627-988b-4096-8397-48cae1a68157",
                DrivingLicenseNumber = "44569627",
                VehicleId = "e0dec8e7-92c7-441e-ad75-55f8234fad59",
                RenterDiscount = 0,
                RentDays = 1,
                HiredCarPricePerDay = 150,
                RegisteredOn = DateTime.Now,
                TotalValue = 150
            };

            string actualRenterId = await rentService.CreateRenterAsync(model);
            string expectedRenterId =
                (await repo!.AllReadonly<Renter>(
                    r => r.ApplicationUserId == model.ApplicationUserId &&
                    r.DrivingLicenseNumber == model.DrivingLicenseNumber &&
                    r.RegisteredOn == model.RegisteredOn).FirstOrDefaultAsync())?.Id.ToString()?? "";

            Guid actualRenterGuidId = new Guid(actualRenterId);
            Guid vehicleGuidId = new Guid(model.VehicleId);

            var order = await repo.AllReadonly<Order>(
                o => o.RenterId == actualRenterGuidId && o.VehicleId == vehicleGuidId).FirstOrDefaultAsync();

            Assert.That(actualRenterId, Is.EqualTo(expectedRenterId));
            Assert.That(order?.IsDeleted?? true, Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private static async Task SeedDbAsync(IRepository repository)
        {
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

            Order nextOrder = new()
            {
                Id = new Guid("3ac3cf02-f88d-4b3b-8687-b3f54c534510"),
                VehicleId = new Guid("f31db974-2830-410d-b435-66844298846a"),
                IsDeleted = false,
                RenterId = new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                TotalDays = 1,
                Price = 250,
                TotalPriceWithDiscounts = 250,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,

            };

            Order deletedOrder = new()
            {
                Id = new Guid("2a58276a-a51d-480e-bc99-e381aee4bdb3"),
                VehicleId = new Guid("82ea3f6a-4782-41d0-bc2d-6ca2f7f9acea"),
                IsDeleted = true,
                RenterId = new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                TotalDays = 1,
                Price = 250,
                TotalPriceWithDiscounts = 250,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                
            };

            await repository.AddRangeAsync(new List<Order>() { order, nextOrder, deletedOrder });

            Vehicle vehicle =
                await repository.GetByIdAsync<Vehicle>(new Guid("779bd522-2646-40b0-90a9-af4ddb9551a5"));

            vehicle.IsRented = true;

            Vehicle nextVehicle =
                await repository.GetByIdAsync<Vehicle>(new Guid("f31db974-2830-410d-b435-66844298846a"));

            nextVehicle.IsRented = true;

            Discount discount = new()
            {
                Id = new Guid("e459d55c-1e39-477b-803f-f01693b57757"),
                Name = "ChristmassDiscount",
                DiscountSize = 50,
                VehicleDiscounts = new HashSet<VehicleDiscount>()
                {
                   new VehicleDiscount()
                   {
                       VehicleId = new Guid("779bd522-2646-40b0-90a9-af4ddb9551a5"),
                       DiscountId = new Guid("e459d55c-1e39-477b-803f-f01693b57757")
                   }
                }
            };

            await repository.AddAsync(discount);

            await repository.SaveChangesAsync();

        }
    }
}

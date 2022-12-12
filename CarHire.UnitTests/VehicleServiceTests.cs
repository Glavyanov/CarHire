namespace CarHire.UnitTests
{

    [TestFixture]
    public class VehicleServiceTests
    {
        private InMemoryDbContext dbContext;
        private ServiceProvider serviceProvider;
        private IVehicleService vehicleService;


        [SetUp]
        public async Task SetUp()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection.
                AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IVehicleService, VehicleService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            await SeedDbAsync(repo!);

            vehicleService = serviceProvider.GetService<IVehicleService>()!;
        }


        [Test]
        public async Task ExistsAsyncShouldReturnCorrectType() =>
            Assert.IsInstanceOf<bool>(await vehicleService.ExistsAsync("foo"));

        [Test]
        [TestCase("779BD522-2646-40B0-90A9-AF4DDB9551A5")]
        [TestCase("F31DB974-2830-410D-B435-66844298846A")]
        [TestCase("82EA3F6A-4782-41D0-BC2D-6CA2F7F9ACEA")]
        [TestCase("E0DEC8E7-92C7-441E-AD75-55F8234FAD59")]
        public async Task ExistsAsyncShouldReturnTrue(string vehicleID) =>
            Assert.That(await vehicleService.ExistsAsync(vehicleID), Is.True);

        [Test]
        [TestCase("D95ABAA0-683D-431D-BD19-3A93C06B037F")]
        public async Task ExistsAsyncShouldReturnFalseWhenVehicleIsDeleted(string vehicleID) =>
            Assert.That(await vehicleService.ExistsAsync(vehicleID), Is.False);

        [Test]
        [TestCase("D95ABAA0")]
        [TestCase("foo")]
        [TestCase("")]
        [TestCase("          ")]
        public async Task ExistsAsyncShouldReturnFalseWhenPassedIncorrectData(string vehicleID) =>
            Assert.That(await vehicleService.ExistsAsync(vehicleID), Is.False);

        [Test]
        public async Task GetAllAsyncShouldReturnCorrectType() =>
            Assert.IsInstanceOf<IEnumerable<VehicleHomeModel>>(await vehicleService.GetAllAsync());

        [Test]
        public async Task GetAllAsyncShouldRetutnCorrectCount() =>
            Assert.That((await vehicleService.GetAllAsync()).Count(), Is.EqualTo(6));

        [Test]
        public async Task GetAllAsyncShouldRetutnCorrectOrderedCollection()
        {
            var firstVehicleId = (await vehicleService.GetAllAsync()).ElementAt(0).Id;
            var secondVehicleId = (await vehicleService.GetAllAsync()).ElementAt(1).Id;
            var lastVehicleId = (await vehicleService.GetAllAsync()).ElementAt(^1).Id;

            Assert.Multiple(() =>
            {

                Assert.That(firstVehicleId, Is.EqualTo("779BD522-2646-40B0-90A9-AF4DDB9551A5"));
                Assert.That(secondVehicleId, Is.EqualTo("F31DB974-2830-410D-B435-66844298846A"));
                Assert.That(lastVehicleId, Is.EqualTo("94FE6D01-FEA0-48B2-B0A6-F884F6DA6EBB"));
            });
        }

        [Test]
        public async Task GetVehicleDetailsByIdAsyncShouldReturnCorrectType() =>
            Assert.IsInstanceOf<VehicleDetailsModel>(
                await vehicleService.GetVehicleDetailsByIdAsync("779BD522-2646-40B0-90A9-AF4DDB9551A5"));

        [Test]
        [TestCase("779BD522-2646-40B0-90A9-AF4DDB9551A5")]
        [TestCase("F31DB974-2830-410D-B435-66844298846A")]
        [TestCase("B544D7B1-7F17-4213-9823-90E82C66DB2E")]
        public async Task GetVehicleDetailsByIdAsyncShouldReturnCorrectVehicle(string expected)
        {
            string actualId = (await vehicleService.GetVehicleDetailsByIdAsync(expected)).Id;

            Assert.That(actualId, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public async Task GetVehiclesByCategoryAsyncShouldReturnCorrectType(int categoryId) =>
            Assert.IsInstanceOf<IEnumerable<VehicleHomeModel>>(
                await vehicleService.GetVehiclesByCategoryAsync(categoryId));

        [Test]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        public async Task GetVehiclesByCategoryAsyncShouldReturnCorrectCount(int categoryId, int expected) =>
           Assert.That((await vehicleService.GetVehiclesByCategoryAsync(categoryId)).Count(), Is.EqualTo(expected));

        [Test]
        [TestCase("94FE6D01-FEA0-48B2-B0A6-F884F6DA6EBB")]
        [TestCase("779BD522-2646-40B0-90A9-AF4DDB9551A5")]
        [TestCase("82EA3F6A-4782-41D0-BC2D-6CA2F7F9ACEA")]
        public async Task DropVehicleAsyncShouldShouldWorkCorrect(string vehicleId)
        {
            var vehicle = await vehicleService.GetVehicleDetailsByIdAsync(vehicleId);
            if (!vehicle.IsRented)
            {
                vehicle.IsRented = true;
            }

            await vehicleService.DropVehicleAsync(vehicleId);

            vehicle = await vehicleService.GetVehicleDetailsByIdAsync(vehicleId);
            Assert.That(vehicle.IsRented, Is.False);
        }

        [Test]
        public async Task GetCategoriesAsyncShouldReturnCorrectType() =>
            Assert.IsInstanceOf<IEnumerable<VehicleCategoryModel>>(await vehicleService.GetCategoriesAsync());

        [Test]
        public async Task GetCategoriesAsyncShouldReturnCorrectCount() =>
            Assert.That((await vehicleService.GetCategoriesAsync()).Count(), Is.EqualTo(4));

        [Test]
        [TestCase("Passenger")]
        [TestCase("Light comercial")]
        [TestCase("Heavy-Duty")]
        [TestCase("Bus")]
        public async Task GetCategoriesAsyncShouldReturnCorrectItems(string name) 
        {
            var categories = await vehicleService.GetCategoriesAsync();

            Assert.That(categories.Where(x => x.Name == name).Any(), Is.True);
        }

        [Test]
        public void GetTransmissionsShouldReturnCorrectType() =>
            Assert.IsInstanceOf<IEnumerable<TransmissionModel>>(vehicleService.GetTransmissions());

        [Test]
        public void GetTransmissionsShouldShouldReturnCorrectCount() =>
            Assert.That(vehicleService.GetTransmissions().Count(), Is.EqualTo(4));

        [Test]
        [TestCase("CVT")]
        [TestCase("SemiAutomatic")]
        [TestCase("Manual")]
        [TestCase("Automatic")]
        public void GetTransmissionsShouldShouldReturnCorrectItems(string name) =>
            Assert.That(vehicleService.GetTransmissions().Where(x => x.TransmissionType == name).Any(), Is.True);

        [Test]
        public void GetSuspensionsShouldReturnCorrectType() =>
            Assert.IsInstanceOf<IEnumerable<SuspensionModel>>(vehicleService.GetSuspensions());

        [Test]
        public void GetSuspensionsShouldShouldReturnCorrectCount() =>
            Assert.That(vehicleService.GetSuspensions().Count(), Is.EqualTo(3));

        [Test]
        [TestCase("Sport")]
        [TestCase("Comfort")]
        [TestCase("Hydropneumatic")]
        public void GetSuspensionsShouldShouldReturnCorrectItems(string name) =>
            Assert.That(vehicleService.GetSuspensions().Where(x => x.SuspensionType == name).Any(), Is.True);

        [Test]
        public void GetFuelsShouldReturnCorrectType() =>
            Assert.IsInstanceOf<IEnumerable<FuelModel>>(vehicleService.GetFuels());

        [Test]
        public void GetFuelsShouldShouldReturnCorrectCount() =>
            Assert.That(vehicleService.GetFuels().Count(), Is.EqualTo(5));

        [Test]
        [TestCase("Electric")]
        [TestCase("Hybrid")]
        [TestCase("LPG")]
        [TestCase("Petrol")]
        [TestCase("Diesel")]
        public void GetFuelsShouldShouldReturnCorrectItems(string name) =>
            Assert.That(vehicleService.GetFuels().Where(x => x.FuelType == name).Any(), Is.True);

        [Test]
        public async Task CreateVehicleAsyncShouldWorkCorrect()
        {
            VehicleAddModel model = new()
            {
                Make = "Test",
                Model = "TestModel",
                Year = 2022,
                Kilometers = 100,
                AirCondition = true,
                NavigationSystem = false,
                Seats = 2,
                Doors = 2,
                SuspensionId = 1,
                FuelId = 1,
                TransmissionId = 1,
                CategoryId = 2,
                ImageUrl = "676ba9ae-13e8-4f71-a9f9-2a4e5349496a",
                TankCapacity = 2,
                Consumption = 2,
                PricePerDay = 200
            };

            await vehicleService.CreateVehicleAsync(model);

            Assert.That((await vehicleService.GetAllAsync()).Any(v => v.ImageUrl == model.ImageUrl), Is.True);
        }

        [Test]
        public async Task GetVehicleEditModelAsyncShouldReturnCorrectType() =>
            Assert.IsInstanceOf<VehicleEditModel>(
                await vehicleService.GetVehicleEditModelAsync("D95ABAA0-683D-431D-BD19-3A93C06B037F"));

        [Test]
        [TestCase("d95abaa0-683d-431d-bd19-3a93c06b037f", "Ailsa B55")]
        [TestCase("94fe6d01-fea0-48b2-b0a6-f884f6da6ebb", "Ailsa B55")]
        [TestCase("e0dec8e7-92c7-441e-ad75-55f8234fad59", "Actros")]
        public async Task GetVehicleEditModelAsyncShouldReturnCorrectVehicle(string id, string model)
        {
            VehicleEditModel editModel = await vehicleService.GetVehicleEditModelAsync(id);
            Assert.Multiple(() =>
            {
                Assert.That(editModel.Id, Is.EqualTo(id));
                Assert.That(editModel.Model, Is.EqualTo(model));
            });
        }

        [Test]
        public async Task EditVehicleAsyncShouldWorkCorrect()
        {
            VehicleEditModel model = new()
            {
                Id = "D95ABAA0-683D-431D-BD19-3A93C06B037F",
                Make = "Test",
                Model = "TestModel",
                Kilometers = 100,
                AirCondition = true,
                NavigationSystem = false,
                Seats = 2,
                Doors = 2,
                SuspensionId = 1,
                FuelId = 1,
                TransmissionId = 1,
                CategoryId = 2,
                ImageUrl = "676ba9ae-13e8-4f71-a9f9-2a4e5349496a",
                TankCapacity = 2,
                Consumption = 2,
                PricePerDay = 200,
                IsDeleted = false,
                IsRented = false,
                
            };

            await vehicleService.EditVehicleAsync(model);

            var vehicle = await vehicleService.GetVehicleEditModelAsync(model.Id);

            Assert.That(model.ImageUrl, Is.EqualTo(vehicle.ImageUrl));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        public static async Task SeedDbAsync(IRepository repo)
        {
            Vehicle deletedVehicle = new()
            {
                Id = new Guid("d95abaa0-683d-431d-bd19-3a93c06b037f"),
                CategoryId = 4,
                AirConditioning = true,
                NavigationSystem = true,
                IsDeleted = true,
                IsRented = false,
                Make = "Volvo",
                Model = "Ailsa B55",
                Year = 1985,
                Kilometers = 300_000,
                PricePerDay = 300,
                Fuel = Fuel.Diesel,
                Transmission = Transmission.Automatic,
                Suspension = Suspension.Hydropneumatic,
                ImageUrl = "Volvo_Ailsa_B55.jpg",
                Doors = 4,
                Consumption = 25,
                Seats = 40,
                TankCapacity = 100,
            };
            Vehicle rentedVehicle = new()
            {
                Id = new Guid("94fe6d01-fea0-48b2-b0a6-f884f6da6ebb"),
                CategoryId = 4,
                AirConditioning = true,
                NavigationSystem = true,
                IsDeleted = false,
                IsRented = true,
                Make = "Volvo",
                Model = "Ailsa B55",
                Year = 1985,
                Kilometers = 300_000,
                PricePerDay = 300,
                Fuel = Fuel.Diesel,
                Transmission = Transmission.Automatic,
                Suspension = Suspension.Hydropneumatic,
                ImageUrl = "Volvo_Ailsa_B55.jpg",
                Doors = 4,
                Consumption = 25,
                Seats = 40,
                TankCapacity = 100,
            };

            await repo.AddRangeAsync(new List<Vehicle>() { deletedVehicle, rentedVehicle });
            await repo.SaveChangesAsync();
        }
    }
}

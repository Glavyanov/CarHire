using CarHire.Core.Models.Role;
using CarHire.Core.Models.User;
using CarHire.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Moq;

namespace CarHire.UnitTests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<UserManager<ApplicationUser>> mockUserManager;
        private InMemoryDbContext dbContext;
        private ServiceProvider serviceProvider;
        private UserService userService;
        private IRepository repo;

        [SetUp]
        public async Task SetUp()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .BuildServiceProvider();

            repo = serviceProvider.GetService<IRepository>()!;

            await SeedDbAsync(repo!);

            mockUserManager = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            var adminUser = await repo.GetByIdAsync<ApplicationUser>("44569627-988b-4096-8397-48cae1a68157");

            mockUserManager.Setup(p =>  p.IsInRoleAsync(adminUser,"Admin"))
                .ReturnsAsync(true);

            mockUserManager.Setup(p => p.RemoveFromRoleAsync(adminUser, "Admin"))
                .ReturnsAsync(IdentityResult.Failed());

            userService = new UserService(repo, mockUserManager.Object);
        }

        [Test]
        public async Task GetAllUsersAsyncShouldReturnCorrectType() =>
            Assert.IsInstanceOf<IEnumerable<UserRoleModel>>(await userService.GetAllUsersAsync());

        [Test]
        public async Task GetAllUsersAsyncShouldReturnCorrectTypeForInnerCollectionRoles() =>
            Assert.IsInstanceOf<List<RoleModel>>(
                (await userService.GetAllUsersAsync()).ElementAt(0).Roles);

        [Test]
        public async Task GetAllUsersAsyncShouldReturnCorrectCount()
        {
            Assert.That((await userService.GetAllUsersAsync()).Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetAllUsersAsyncShouldReturnCorrectCountForInnerCollectionRoles()
        {
            Assert.That((await userService.GetAllUsersAsync()).ElementAt(0).Roles, Has.Count.EqualTo(3));
        }

        [Test]
        [TestCase("44569627-988b-4096-8397-48cae1a68157")]
        [TestCase("27fba6ae-8175-4484-9b0d-917d6b32c851")]
        public async Task GetAllUsersAsyncShouldReturnCorrectUsers(string userId)
        {
            Assert.That((await userService.GetAllUsersAsync()).Any(x => x.Id == userId), Is.True);
        }

        [Test]
        [TestCase("4456962")]
        [TestCase("foo")]
        [TestCase("")]
        public async Task GetAllUsersAsyncShouldReturnEmptyCollection(string userId)
        {
            Assert.That((await userService.GetAllUsersAsync()).Any(x => x.Id == userId), Is.False);
        }

        [Test]
        public void AddUserToRoleAsyncShouldThrowsArgumentException()
        {
            string userId = "44569627-988b-4096-8397-48cae1a68157";
            string roleId = "5208a8e1-ff35-4845-9cb3-cc19d1434c11";

            Assert.CatchAsync<ArgumentException>(async () => await userService.AddUserToRoleAsync(userId, roleId));
        }

        [Test]
        public async Task AddUserToRoleAsyncShouldWorkCorrect()
        {
            string userId = "44569627-988b-4096-8397-48cae1a68157";
            string roleId = "9edf0e69-d62a-433b-99dd-9739a7d8867d";

            await userService.AddUserToRoleAsync(userId, roleId);

            Assert.That(
                await repo.AllReadonly<IdentityUserRole<string>>(
                    u => u.UserId == userId && u.RoleId == roleId)
                .AnyAsync(), Is.True);
        }

        [Test]
        public void RemoveUserFromRoleAsyncShouldThrowsArgumentExceptionWhenUserIsNotInRole()
        {
            string userId = "44569627-988b-4096-8397-48cae1a68157";
            string roleId = "fc4fdb35-719a-4ac2-8041-2e5034d2bae6";

            Assert.CatchAsync<ArgumentException>(
                async () => await userService.RemoveUserFromRoleAsync(userId, roleId));
        }

        [Test]
        public void RemoveUserFromRoleAsyncShouldThrowsArgumentExceptionWhenNotSuccesfullyRemovedFromRole()
        {
            string userId = "44569627-988b-4096-8397-48cae1a68157";
            string roleId = "5208a8e1-ff35-4845-9cb3-cc19d1434c11";

            Assert.CatchAsync<ArgumentException>(
                async () => await userService.RemoveUserFromRoleAsync(userId, roleId));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        public static async Task SeedDbAsync(IRepository repo)
        {

            IdentityRole testRole = new IdentityRole()
            {
                Id = "9edf0e69-d62a-433b-99dd-9739a7d8867d",
                Name = "Test",
                NormalizedName = "TEST".ToUpper()
            };

            await repo.AddAsync(testRole);
            await repo.SaveChangesAsync();
        }
    }
}

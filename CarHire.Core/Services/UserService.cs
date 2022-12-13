namespace CarHire.Core.Services
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    using CarHire.Core.Contracts;
    using CarHire.Core.Models.User;
    using CarHire.Infrastructure.Data.Common;
    using CarHire.Infrastructure.Data.Entities;
    using CarHire.Core.Models.Role;

    public class UserService : IUserService
    {

        private readonly IRepository repo;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(IRepository _repo, UserManager<ApplicationUser> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
        }

        public async Task AddUserToRoleAsync(string userId, string roleId)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(userId);
            var roleName = await repo.GetByIdAsync<IdentityRole>(roleId);

            if (await userManager.IsInRoleAsync(user, roleName?.Name))
            {
                throw new ArgumentException();
            }
            IdentityUserRole<string> userRole = new()
            {
                UserId = userId,
                RoleId = roleId
            };

            await repo.AddAsync(userRole);
            await repo.SaveChangesAsync();
        }

        public async Task RemoveUserFromRoleAsync(string userId, string roleId)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(userId);
            var roleName = await repo.GetByIdAsync<IdentityRole>(roleId);

            if (!await userManager.IsInRoleAsync(user, roleName?.Name))
            {
                throw new ArgumentException();
            }

            var result = await userManager.RemoveFromRoleAsync(user, roleName?.Name);

            if (!result.Succeeded)
            {
                throw new ArgumentException();
            }

        }

        public async Task<IEnumerable<UserRoleModel>> GetAllUsersAsync()
        {
            var roles = await repo.AllReadonly<IdentityRole>()
                .Select(r => new RoleModel()
                {
                    Id = r.Id,
                    RoleName = r.Name
                }).ToListAsync();

            return await repo.AllReadonly<ApplicationUser>()
                .Select(u => new UserRoleModel()
                {
                    Id = u.Id,
                    FullName = $"{u.FirstName} {u.LastName}",
                    Email = u.Email,
                    Roles = roles

                }).ToListAsync();
        }
    }
}

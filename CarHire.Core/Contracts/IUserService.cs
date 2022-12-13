namespace CarHire.Core.Contracts
{
    using CarHire.Core.Models.User;
    public interface IUserService
    {
        Task<IEnumerable<UserRoleModel>> GetAllUsersAsync();

        Task AddUserToRoleAsync(string userId, string roleId);

        Task RemoveUserFromRoleAsync(string userId, string roleId);
    }
}

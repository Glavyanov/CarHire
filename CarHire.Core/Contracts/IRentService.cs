namespace CarHire.Core.Contracts
{
    using CarHire.Core.Models.Renter;
    using CarHire.Core.Models.Vehicle;
    using CarHire.Infrastructure.Data.Entities;

    public interface IRentService
    {
        Task<RenterHomeModel> GetRenterByIdAsync(string id);

        Task<VehicleRentModel> GetVehicleRentByIdAsync(string id);

        Task<bool> ExistsByApplicationUserIdAsync(string id);

        Task<string> CreateRenterAsync(RenterHomeModel model);

        Task<List<VehicleHomeModel>> GetVehiclesByRenterIdAsync(string id);

        Task<bool> DeleteOrderAsync(string vehicleId, string applicationUserId);
    }
}

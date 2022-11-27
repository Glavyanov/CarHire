namespace CarHire.Core.Contracts
{
    using CarHire.Core.Models.Renter;
    using CarHire.Core.Models.Vehicle;

    public interface IRentService
    {
        Task<RenterHomeModel> GetRenterByIdAsync(string id);

        Task<VehicleRentModel> GetVehicleRentByIdAsync(string id);

        Task<bool> ExistsbyApplicationUserIdAsync(string id);

        Task<string> CreateRenterAsync(RenterHomeModel model);

    }
}

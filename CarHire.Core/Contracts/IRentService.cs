namespace CarHire.Core.Contracts
{
    using CarHire.Core.Models.Renter;
    using CarHire.Core.Models.Vehicle;

    public interface IRentService
    {
        Task<RenterHomeModel> GetRenterByIdAsync(string id);

        Task<VehicleRentModel> GetVehicleRentByIdAsync(string id);
    }
}

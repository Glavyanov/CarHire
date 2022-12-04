namespace CarHire.Core.Contracts
{
    using CarHire.Core.Models.Vehicle;
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleHomeModel>> GetAllAsync();

        Task<IEnumerable<VehicleHomeModel>> GetVehiclesByCategoryAsync(int categoryId);

        Task<VehicleDetailsModel> GetVehicleDetailsByIdAsync(string id);

        Task<bool> ExistsAsync(string id);

        Task DropVehicleAsync(string id);
    }
}

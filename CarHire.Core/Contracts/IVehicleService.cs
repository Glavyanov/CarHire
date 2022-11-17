namespace CarHire.Core.Contracts
{
    using CarHire.Core.Models.Vehicle;
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleHomeModel>> GetVehiclesAsync(string category);
    }
}

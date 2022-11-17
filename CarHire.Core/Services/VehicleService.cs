namespace CarHire.Core.Services
{
    using Microsoft.EntityFrameworkCore;

    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Vehicle;
    using CarHire.Infrastructure.Data.Common;
    using CarHire.Infrastructure.Data.Entities;

    public class VehicleService : IVehicleService
    {
        private readonly IRepository repo;

        public VehicleService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<VehicleHomeModel>> GetVehiclesAsync(string category)
        {
            return await repo.AllReadonly<Vehicle>()
                .Where(v => v.Category.Name == category)
                .Select(v => new VehicleHomeModel() 
                {
                    ImageUrl = v.ImageUrl 
                })
                .ToListAsync();
        }
    }
}

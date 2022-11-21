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

        public async Task<IEnumerable<VehicleHomeModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Vehicle>()
                .OrderBy(v => v.CategoryId)
                .Select(v => new VehicleHomeModel()
                {
                    ImageUrl = v.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<VehicleHomeModel>> GetVehiclesByCategoryAsync(int categoryId)
        {
            return await repo.AllReadonly<Vehicle>()
                .Where(v => v.CategoryId == categoryId)
                .Select(v => new VehicleHomeModel() 
                {
                    ImageUrl = v.ImageUrl 
                })
                .ToListAsync();
        }
    }
}

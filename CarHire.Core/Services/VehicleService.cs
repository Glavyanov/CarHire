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

        public async Task<bool> ExistsAsync(string id)
        {
            return await repo.AllReadonly<Vehicle>(v => v.Id.ToString() == id && !v.IsDeleted).AnyAsync();
        }

        public async Task<IEnumerable<VehicleHomeModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Vehicle>(x => !x.IsDeleted)
                .OrderBy(v => v.CategoryId)
                .Select(v => new VehicleHomeModel()
                {
                    Id = v.Id.ToString(),
                    ImageUrl = v.ImageUrl,
                    IsRented = v.IsRented
                })
                .ToListAsync();
        }

        public async Task<VehicleDetailsModel> GetVehicleDetailsByIdAsync(string id)
        {
            return await repo.AllReadonly<Vehicle>(v => v.Id.ToString() == id && !v.IsDeleted)
                .Select(x => new VehicleDetailsModel()
                {
                    Id = x.Id.ToString(),
                    Make = x.Make,
                    Model = x.Model,
                    ImageUrl = x.ImageUrl,
                    Year = x.Year,
                    IsRented = x.IsRented,
                    Transmission = x.Transmission.ToString(),
                    Suspension = x.Suspension.ToString(),
                    FuelType = x.Fuel.ToString(),
                    AirCondition = x.AirConditioning,
                    NavigationSystem = x.NavigationSystem,
                    CategoryName = x.Category.Name,
                    Consumption = x.Consumption,
                    Doors = x.Doors,
                    PricePerDay = x.PricePerDay,
                    Seats = x.Seats,
                    TankCapacity = x.TankCapacity

                }).FirstAsync();
        }

        public async Task<IEnumerable<VehicleHomeModel>> GetVehiclesByCategoryAsync(int categoryId)
        {
            return await repo.AllReadonly<Vehicle>(x => !x.IsDeleted && !x.IsRented)
                .Where(v => v.CategoryId == categoryId)
                .Select(v => new VehicleHomeModel()
                {
                    Id = v.Id.ToString(),
                    ImageUrl = v.ImageUrl
                })
                .ToListAsync();
        }
    }
}

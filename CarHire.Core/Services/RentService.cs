namespace CarHire.Core.Services
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Renter;
    using CarHire.Core.Models.Vehicle;
    using CarHire.Infrastructure.Data.Common;
    using CarHire.Infrastructure.Data.Entities;

    public class RentService : IRentService
    {
        private readonly IRepository repo;

        public RentService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<string> CreateRenterAsync(RenterHomeModel model)
        {
            Guid vehicleId = Guid.Parse(model.VehicleId);
            Vehicle vehicle = await repo.GetByIdAsync<Vehicle>(vehicleId);
            if (vehicle.PricePerDay > model.HiredCarPricePerDay)
            {
                throw new ArgumentException("The price is manipulated!");
            }

            Renter renter = new()
            {
                ApplicationUserId = model.ApplicationUserId,
                RenterDiscount = model.RenterDiscount,
                DrivingLicenseNumber = model.DrivingLicenseNumber,
                RegisteredOn = model.RegisteredOn,
                TotalValue = model.TotalValue,
            };

            vehicle.IsRented = true;

            await repo.AddAsync<Renter>(renter);
            await repo.SaveChangesAsync();

            return renter.Id.ToString();
        }

        public async Task<bool> ExistsbyApplicationUserIdAsync(string id)
        {
            return await repo.All<Renter>(r => r.ApplicationUserId == id).AnyAsync();
        }

        public async Task<RenterHomeModel> GetRenterByIdAsync(string id)
        {
            Guid renterGuid = Guid.Parse(id);

            var renter = await repo.GetByIdAsync<Renter>(renterGuid);

            RenterHomeModel model = new()
            {
                Id = renter.Id.ToString()
            };

            return model;
        }

        public async Task<VehicleRentModel> GetVehicleRentByIdAsync(string id)
        {
            return await repo.All<Vehicle>(v => v.Id.ToString() == id && !v.IsDeleted)
                .Select(v => new VehicleRentModel()
                {
                    Id = v.Id.ToString(),
                    ImageUrl = v.ImageUrl,
                    IsRented = v.IsRented,
                    PricePerDay = v.PricePerDay

                }).FirstAsync();
        }
    }
}

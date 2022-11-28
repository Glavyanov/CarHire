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
            Vehicle vehicle = 
                await repo.All<Vehicle>(v => v.Id == vehicleId)
                .Include(x => x.VehicleDiscounts)
                .ThenInclude(x => x.Discount)
                .FirstAsync();

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

            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(model.RentDays);

            int discount = 0;
            if (vehicle.VehicleDiscounts.Any())
            {
                discount = vehicle.VehicleDiscounts.Sum(s => s.Discount.DiscountSize);
            }
            decimal totalPriceWithDiscount = 
                Math.Round( model.TotalValue * (decimal)(1 - (discount * 1.00 / 100)), 2);

            Order order = new()
            {
                RenterId = renter.Id,
                VehicleId = vehicleId,
                StartDate = startDate,
                EndDate = endDate,
                Discount = discount,
                TotalDays = model.RentDays,
                Price = model.TotalValue,
                TotalPriceWithDiscount = totalPriceWithDiscount,
                IsDeleted = false
            };

            await repo.AddAsync<Order>(order);
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

        //TODO DELETE
        /*public async Task<List<Vehicle>> GetVehiclesByRenterId(string id)
        {
            var renter = await repo.AllReadonly<Renter>(x => x.ApplicationUserId == id).FirstAsync();
            var vehiclesId = await repo.AllReadonly<Order>(o => o.RenterId == renter.Id)
                .Select(x => x.VehicleId)
                .ToListAsync();
            List<Vehicle> vehicles = new();
            foreach (var item in vehiclesId)
            {
                var vehicle = await repo.AllReadonly<Vehicle>(x => x.Id == item).FirstAsync();
                vehicles.Add(vehicle);
            }

            return vehicles;
        }*/
    }
}
